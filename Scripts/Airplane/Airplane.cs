//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;
using Photon.Realtime;
public class Airplane : MonoBehaviourPun
{
	public AirplaneWingController wingController;
	public AirplaneInputController inputController;
	public Engine engine;
	private float currentHealth;
	public float maxHealth;
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

	public WheelCollider backWheel;
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;

	public float boostSpeed = 220000f;
	public float trim;

	private float fireDeltaMs = 0.2f;
	private float currentFireDeltaMs = 0;
	private bool firing = false;

	private bool braking = false;
	private float brakeFoce = 10000f;

	private bool active;
	private RectTransform myTracker;
	private bool alive = false;

	private float waterAltitude = 1221f;
	private float takeOffAltitude = 600f; //relative to water
	public float altitude;

	private	const float msToKnots = 1.94384f;

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
			inputController.active = false;
		}
		else//local
		{
			wingController.ActivateWings();
			CursorController.instance.ForceHide();
			Hashtable hashTable = new Hashtable();
			hashTable["deaths"] = 0;
			hashTable["kills"] = 0;
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashTable);
			active = true;
			currentHealth = maxHealth;
		}
		alive = true;
	}

	private void CheckVelocityActions()
	{//Watch out - this also runs remotely
		float velocity = rigid.velocity.magnitude * msToKnots;
		if(velocity > 350f) waterVapor.SetActive(true);
		if(velocity < 350f) waterVapor.SetActive(false);
		if (this.photonView.IsMine == false) return;
		if (velocity > 500f) GameController.instance.cameraController.EnableScreenShake();
		if (velocity < 500f) GameController.instance.cameraController.DisableScreenShake();
	}

	private void CheckAltitudeActions()
	{
		altitude = transform.position.y - waterAltitude;
		if (altitude > takeOffAltitude + 10f) AudioController.instance.TriggerFlyingMusic();
	}

	public void ToggleGun(bool enable)
	{
		if(enable) currentFireDeltaMs = fireDeltaMs;
		firing = enable;
	}
	public void ToggleBrake(bool enabled)
	{
		
		if (enabled) braking = true;
		if (!enabled) braking = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!active || !alive) return;

		CheckVelocityActions(); //Do check this for public to show the right animations

		if (this.photonView.IsMine == false) return; // Quit if remote

		CheckAltitudeActions();

		if (firing)
		{
			currentFireDeltaMs += Time.deltaTime;
			if (fireDeltaMs > currentFireDeltaMs) return;
			NetworkManager.instance.SendFireBullet(turret.position, transform.rotation, rigid.velocity);
			currentFireDeltaMs = 0f;
		}

		if (braking) backWheel.brakeTorque = leftWheel.brakeTorque = rightWheel.brakeTorque = brakeFoce;
		else backWheel.brakeTorque = leftWheel.brakeTorque = rightWheel.brakeTorque = 0f;
	}

	private void OnGUI()
	{
		if (this.photonView.IsMine == false) return;
		GUI.Label(new Rect(10, 40, 300, 20), string.Format("Speed: {0:0.0} knots", rigid.velocity.magnitude * msToKnots));
		GUI.Label(new Rect(10, 80, 300, 20), string.Format("Altitude: {0} m", altitude));
	}

	[PunRPC]
	public void DamageMe(float damage, string ownerID)
	{
		smoke.SetActive(true);

		if (this.photonView.IsMine)//local
		{
			currentHealth -= damage;
			UIController.instance.SetHealth(currentHealth / maxHealth);
		}

		if (currentHealth <= 0)
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
				this.photonView.RPC("KillMe", RpcTarget.All);
			}
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
		waterVapor.SetActive(false);
		plane.SetActive(false);
		engine.EndBoost();

		if (this.photonView.IsMine == false)//remote
		{
			myTracker.gameObject.SetActive(false);
		}
		else //local
		{
			engine.SetThrottle(0f);
			CursorController.instance.ForceShow();
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
		transform.rotation = GameController.instance.startNode.rotation;
		plane.SetActive(true);
		explosion.SetActive(false);
		smoke.SetActive(false);
		rigid.isKinematic = false;
		leftTrail.Clear();
		rightTrail.Clear();
		CursorController.instance.ForceHide();
		if (this.photonView.IsMine == false)//remote
		{
			myTracker.gameObject.SetActive(true);
			myTracker.anchoredPosition = new Vector3(9999f, 9999f, 9999f);
		}
		else //local
		{
			currentHealth = maxHealth;
			engine.ResetBoost();
			UIController.instance.SetHealth(1f);
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
			Debug.Log("kill me through collision");
			this.photonView.RPC("KillMe", RpcTarget.All);
		}
		if (collision.gameObject.tag == "Damage")
		{
			IDamageHit hit = collision.gameObject.GetComponent<IDamageHit>();
			this.photonView.RPC("DamageMe", RpcTarget.All, hit.damage, hit.owner.UserId);
		}
	}
}
