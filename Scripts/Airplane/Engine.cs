//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using Photon.Pun;
using UnityEngine;

public class Engine : MonoBehaviour
{
	[Range(0, 1)]
	public float throttle;

	[Tooltip("How much power the engine puts out.")]
	public float thrust;

	private Rigidbody rigid;

	public bool activePlayer = true;

	private bool running = false;

	public float boostSpeed = 220000f;
	public float normalSpeed = 60000f;

	public AK.Wwise.Event startEngineStart;
	public AK.Wwise.Event startEngineBoost;
	public AK.Wwise.Event startEngineRunning;
	public AK.Wwise.Event stopEngineRunning;

	private void Awake()
	{
		rigid = GetComponentInParent<Rigidbody>();
	}

	public void SetThrottle(float _throttle)
	{
		throttle = Mathf.Clamp01(_throttle);
		UIController.instance.throttleIndicator.pivot = new Vector2(0, throttle);

		if (throttle == 0 && running)
		{
			stopEngineRunning.Post(gameObject);
			running = false;
		}

		if(throttle > 0.1f && !running)
		{
			startEngineStart.Post(gameObject);
			running = true;
		}
	}

	public void Boost()
	{
		thrust = boostSpeed;
		startEngineBoost.Post(gameObject);
	}

	public void EndBoost()
	{
		thrust = normalSpeed;
		if(throttle == 0)
		{
			stopEngineRunning.Post(gameObject);
			return;
		}
		startEngineRunning.Post(gameObject);
	}

	private void FixedUpdate()
	{
		if (rigid != null && activePlayer)
		{
			rigid.AddRelativeForce(Vector3.forward * thrust * throttle, ForceMode.Force);
		}
	}

}
