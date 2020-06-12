//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using System;
using Photon.Realtime;

public class Airplane : MonoBehaviourPun
{

	public AirplaneWingController wingController;

	public Engine engine;
	public float health;
	public Rigidbody rigid;
	public Transform turret;

	public GameObject explosion;
	public GameObject smoke;
	public GameObject plane;
	public GameObject waterVapor;

	public Target myTarget;
	public Transform cameraGimbal;
	public TrailRenderer leftTrail;
	public TrailRenderer rightTrail;

	public float boostSpeed = 220000f;
	public float trim;

	private float fireDeltaMs = 0.2f;
	private float currentFireDeltaMs = 0;
	private bool active;
	private RectTransform myTracker;
	private bool alive = false;

	private void Start()
	{
		SetActive();
	}

	public void SetActive()
	{
		if (this.photonView.IsMine == false)//remote
		{
			engine.activePlayer = false;
			myTracker = UIController.instance.RegisterTarget(myTarget);//TODO Remove use below
			GameController.instance.RegisterOtherPlayerAirplane(this.photonView.Owner, this);
		}
		else//local
		{
			wingController.ActivateWings();
			CursorController.instance.RequestHide();
			Hashtable hashTable = new Hashtable();
			hashTable["deaths"] = 0;
			hashTable["kills"] = 0;
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashTable);
			active = true;
		}
		alive = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (!active || !alive) return; 
		if (this.photonView.IsMine == false) return; // Quit if remote

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl))
		{
			var engineThrottle = engine.throttle;
			engineThrottle += (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) * Time.deltaTime;
			engineThrottle -= (Input.GetKey(KeyCode.LeftControl) ? 1f : 0f) * Time.deltaTime;
			engine.SetThrottle(engineThrottle);
		}

		if (Input.GetMouseButtonDown(0))
		{
			currentFireDeltaMs = fireDeltaMs;
		}

		if (Input.GetMouseButton(0))
		{
			currentFireDeltaMs += Time.deltaTime;
			if (fireDeltaMs < currentFireDeltaMs)
			{
				GameController.instance.FireBulletFrom(turret.position, transform.rotation, rigid.velocity, PhotonNetwork.LocalPlayer);
				NetworkManager.instance.SendFireBullet(turret.position, transform.rotation, rigid.velocity);
				currentFireDeltaMs = 0f;
			};
		}
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			GameController.instance.cameraController.lookAt = false;
		}

		if (Input.GetKey(KeyCode.LeftAlt))
		{
			GameController.instance.cameraController.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), transform.rotation.z));
		}

		if (Input.GetKeyUp(KeyCode.LeftAlt))
		{
			GameController.instance.cameraController.lookAt = true;
		}

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			UIController.instance.ShowScoreboardScreen();
		}

		if (Input.GetKeyUp(KeyCode.Tab))
		{
			UIController.instance.HideScoreboardScreen();
		}

		if (Input.GetMouseButtonDown(1))
		{
			this.photonView.RPC("StartBoost", RpcTarget.All);
		}

		if (Input.GetMouseButtonUp(1))
		{
			this.photonView.RPC("EndBoost", RpcTarget.All);
		}

	}
	[PunRPC]
	public void StartBoost()
	{
		waterVapor.SetActive(true);
		if (this.photonView.IsMine == false) return;
		engine.Boost();
	}
	[PunRPC]
	public void EndBoost()
	{
		waterVapor.SetActive(false);
		if (this.photonView.IsMine == false) return;
		engine.EndBoost();
	}

	private void OnGUI()
	{
		if (this.photonView.IsMine == false) return;
		const float msToKnots = 1.94384f;
		GUI.Label(new Rect(10, 40, 300, 20), string.Format("Speed: {0:0.0} knots", rigid.velocity.magnitude * msToKnots));
	}

	[PunRPC]
	public void DamageMe(float damage, string ownerID)
	{
		health -= damage;
		smoke.SetActive(true);
		if(health <= 0)
		{
			if (this.photonView.IsMine)//local
			{
				Player bulletOwner = GameController.instance.GetPlayerById(ownerID);
				if(bulletOwner != PhotonNetwork.LocalPlayer) { //If you kill yourself, you don't deserve a point, you filthy cheater
					Hashtable hashTable = new Hashtable();
					int kills = (int)bulletOwner.CustomProperties["kills"];
					hashTable["kills"] = kills + 1;
					bulletOwner.SetCustomProperties(hashTable);
				}
			}
			this.photonView.RPC("KillMe", RpcTarget.All);
		}
	}

	[PunRPC]
	public void KillMe()
	{
		if (!alive) return;
		alive = false;
		rigid.isKinematic = true;
		active = false;
		explosion.SetActive(true);
		smoke.SetActive(true);
		plane.SetActive(false);
		this.photonView.RPC("EndBoost", RpcTarget.All);

		if (this.photonView.IsMine == false)//remote
		{
			myTracker.gameObject.SetActive(false);
		}
		else //local
		{
			engine.SetThrottle(0f);
			CursorController.instance.RequestShow();
			UIController.instance.ToggleResetButton(true);

			Hashtable hashTable = new Hashtable();
			int deaths = (int)PhotonNetwork.LocalPlayer.CustomProperties["deaths"];
			hashTable["deaths"] = deaths + 1;
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashTable);
		}
	}

	[PunRPC]
	public void ResetMe()
	{
		active = true;
		alive = true;
		transform.position = GameController.instance.startNode.position;
		transform.rotation = Quaternion.identity;
		explosion.SetActive(false);
		smoke.SetActive(false);
		plane.SetActive(true);
		rigid.isKinematic = false;
		leftTrail.Clear();
		rightTrail.Clear();
		CursorController.instance.RequestHide();
		if (this.photonView.IsMine == false)//remote
		{
			myTracker.gameObject.SetActive(true);
			myTracker.anchoredPosition = new Vector3(9999f, 9999f, 9999f);
		}
		else //local
		{
			UIController.instance.ToggleResetButton(false);
		}
	}

	public void CallResetMe()
	{
		ResetMe();
		this.photonView.RPC("ResetMe", RpcTarget.Others);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (this.photonView.IsMine == false) return;
		if (collision.gameObject.tag == "Kill")
		{
			this.photonView.RPC("KillMe", RpcTarget.All);
		}
		if (collision.gameObject.tag == "Damage")
		{
			IDamageHit hit = collision.gameObject.GetComponent<IDamageHit>();
			this.photonView.RPC("DamageMe", RpcTarget.All, hit.damage, hit.owner.UserId);
		}
	}
}
