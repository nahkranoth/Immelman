﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody rigidBody;
    private float liveTime = 2f;
    private float timeDelta;

    public void Fire(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        transform.position = position;
        transform.rotation = orientation;
        rigidBody.velocity = baseVelocity;
        rigidBody.AddRelativeForce(Vector3.forward * 200, ForceMode.VelocityChange);
        timeDelta = 0f;
    }


    private void FixedUpdate()
    {
        timeDelta += Time.deltaTime;
        if (timeDelta > liveTime)
        {
            Destroy(gameObject);
        }
    }
    
}
