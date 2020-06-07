//
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
	public string name = "ME";
	public Rigidbody rigid;
	public Camera camera;
	public Transform turret;

	public Rigidbody Rigidbody { get; internal set; }

	private float throttle = 1.0f;
	private bool yawDefined = false;
	private float fireDeltaMs = 0.2f;
	private float currentFireDeltaMs = 0;
	private bool active;

	public float trim;

	private void Awake()
	{
		//Rigidbody.velocity = new Vector3(0, 0, 200);
	}

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

	}
	public void FixedUpdate()
	{
		//Debug.Log(rigid.angularVelocity);
		rigid.AddRelativeTorque(new Vector3(trim * 1000f, 0f, 0f));
	}

	private float CalculatePitchG()
	{
		// Angular velocity is in radians per second.
		Vector3 localVelocity = transform.InverseTransformDirection(rigid.velocity);
		Vector3 localAngularVel = transform.InverseTransformDirection(rigid.angularVelocity);

		// Local pitch velocity (X) is positive when pitching down.

		// Radius of turn = velocity / angular velocity
		float radius = (Mathf.Approximately(localAngularVel.x, 0.0f)) ? float.MaxValue : localVelocity.z / localAngularVel.x;

		// The radius of the turn will be negative when in a pitching down turn.

		// Force is mass * radius * angular velocity^2
		float verticalForce = (Mathf.Approximately(radius, 0.0f)) ? 0.0f : (localVelocity.z * localVelocity.z) / radius;

		// Express in G (Always relative to Earth G)
		float verticalG = verticalForce / -9.81f;

		// Add the planet's gravity in. When the up is facing directly up, then the full
		// force of gravity will be felt in the vertical.
		verticalG += transform.up.y * (Physics.gravity.y / -9.81f);

		return verticalG;
	}

	private void OnGUI()
	{
		if (this.photonView.IsMine == false) return;
		const float msToKnots = 1.94384f;
		GUI.Label(new Rect(10, 40, 300, 20), string.Format("Speed: {0:0.0} knots", rigid.velocity.magnitude * msToKnots));
		GUI.Label(new Rect(10, 60, 300, 20), string.Format("Throttle: {0:0.0}%", throttle * 100.0f));
		GUI.Label(new Rect(10, 80, 300, 20), string.Format("G Load: {0:0.0} G", CalculatePitchG()));
	}
}
