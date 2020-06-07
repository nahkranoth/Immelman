﻿//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using UnityEngine;
using System;
using Photon.Pun;

public class Airplane : MonoBehaviourPun
{
	public ControlSurface elevator;
	public ControlSurface aileronLeft;
	public ControlSurface aileronRight;
	public ControlSurface rudder;
	public SimpleWing wing;
	public SimpleWing bodyHor;
	public SimpleWing bodyVert;
	public SimpleWing rudderWing;
	public SimpleWing elevatorWing;
	public SimpleWing aileronLeftWing;
	public SimpleWing aileronRighttWing;
	public Engine engine;
	public float health;
	public Rigidbody rigid;
	public Camera camera;
	public Transform turret;

	public Rigidbody Rigidbody { get; internal set; }
	public GameObject explosion;
	public GameObject smoke;
	public GameObject plane;
	public GameObject waterVapor;

	public float boostSpeed = 220000f;
	public float trim;

	private float throttle = 1.0f;
	private bool yawDefined = false;
	private float fireDeltaMs = 0.2f;
	private float currentFireDeltaMs = 0;
	private bool active;

	private void Start()
	{
		if (elevator == null)
			Debug.LogWarning(name + ": Airplane missing elevator!");
		if (aileronLeft == null)
			Debug.LogWarning(name + ": Airplane missing left aileron!");
		if (aileronRight == null)
			Debug.LogWarning(name + ": Airplane missing right aileron!");
		if (rudder == null)
			Debug.LogWarning(name + ": Airplane missing rudder!");
		if (engine == null)
			Debug.LogWarning(name + ": Airplane missing engine!");

		try
		{
			Input.GetAxis("Yaw");
			yawDefined = true;
		}
		catch (ArgumentException e)
		{
			Debug.LogWarning(e);
			Debug.LogWarning(name + ": \"Yaw\" axis not defined in Input Manager. Rudder will not work correctly!");
		}

		SetActive();
	}

	public void SetActive()
	{
		if (this.photonView.IsMine == false)
		{
			elevator.active = false;
			aileronLeft.active = false;
			aileronRight.active = false;
			rudder.active = false;
			engine.active = false;
			wing.active = false;
			bodyHor.active = false;
			bodyVert.active = false;
			rudderWing.active = false;
			elevatorWing.active = false;
			aileronRighttWing.active = false;
			aileronLeftWing.active = false;
			camera.gameObject.SetActive(false);
		}
		active = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (!active) return;
		if (this.photonView.IsMine == false) return;

		if (elevator != null)
		{
			elevator.targetDeflection = -Input.GetAxis("Vertical");
		}

		if (aileronLeft != null)
		{
			aileronLeft.targetDeflection = -Input.GetAxis("Horizontal");
		}
		if (aileronRight != null)
		{
			aileronRight.targetDeflection = Input.GetAxis("Horizontal");
		}
		if (rudder != null && yawDefined)
		{
			// YOU MUST DEFINE A YAW AXIS FOR THIS TO WORK CORRECTLY.
			// Imported packages do not carry over changes to the Input Manager, so
			// to restore yaw functionality, you will need to add a "Yaw" axis.
			rudder.targetDeflection = Input.GetAxis("Yaw");
		}

		if (engine != null)
		{
			// Fire 1 to speed up, Fire 2 to slow down. Make sure throttle only goes 0-1.
			throttle += (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) * Time.deltaTime;
			throttle -= (Input.GetKey(KeyCode.LeftControl) ? 1f : 0f) * Time.deltaTime;
			throttle = Mathf.Clamp01(throttle);

			engine.throttle = throttle;
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
				GameController.instance.FireBulletFrom(turret.position, transform.rotation, rigid.velocity);
				NetworkManager.instance.SendFireBullet(turret.position, transform.rotation, rigid.velocity);
				currentFireDeltaMs = 0f;
			};
		}

		if (Input.GetMouseButtonDown(1))
		{
			engine.Boost();
			waterVapor.SetActive(true);
		}

		if (Input.GetMouseButtonUp(1))
		{
			engine.EndBoost();
			waterVapor.SetActive(false);
		}

	}
	public void FixedUpdate()
	{
		rigid.AddRelativeTorque(new Vector3(trim * 1000f, 0f, 0f));
	}

	private void OnGUI()
	{
		if (this.photonView.IsMine == false) return;
		const float msToKnots = 1.94384f;
		GUI.Label(new Rect(10, 40, 300, 20), string.Format("Speed: {0:0.0} knots", rigid.velocity.magnitude * msToKnots));
		GUI.Label(new Rect(10, 60, 300, 20), string.Format("Throttle: {0:0.0}%", throttle * 100.0f));
	}

	[PunRPC]
	public void DamageMe(float damage)
	{
		health -= damage;
		smoke.SetActive(true);

		if(health <= 0)
		{
			KillMe();
			this.photonView.RPC("KillMe", RpcTarget.Others);
		}

	}

	[PunRPC]
	public void KillMe()
	{
		rigid.isKinematic = true;
		explosion.SetActive(true);
		smoke.SetActive(true);
		plane.SetActive(false);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (this.photonView.IsMine == false) return;

		if (collision.gameObject.tag == "Kill")
		{//TODO check velocity and if it's wheels that are touching the floor
			KillMe();
			this.photonView.RPC("KillMe", RpcTarget.Others);
			Debug.Log("Kill!");
		}
		if (collision.gameObject.tag == "Damage")
		{
			DamageMe(collision.gameObject.GetComponent<IDamageHit>().damage);
			this.photonView.RPC("DamageMe", RpcTarget.Others, 1f);
			Debug.Log("Damage!");
		}
	}
}