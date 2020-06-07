//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//

using System.Security.Policy;
using UnityEngine;

public class Engine : MonoBehaviour
{
	[Range(0, 1)]
	public float throttle = 1.0f;

	[Tooltip("How much power the engine puts out.")]
	public float thrust;

	private Rigidbody rigid;

	public bool active = true;

	public float boostSpeed = 220000f;
	public float normalSpeed = 60000f;

	private void Awake()
	{
		rigid = GetComponentInParent<Rigidbody>();
	}

	public void Boost()
	{
		thrust = boostSpeed;
	}

	public void EndBoost()
	{
		thrust = normalSpeed;
	}

	private void FixedUpdate()
	{
		if (rigid != null && active)
		{
			rigid.AddRelativeForce(Vector3.forward * thrust * throttle, ForceMode.Force);
		}
	}

}
