using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IDamageHit
{
    public Rigidbody rigidBody;
    public AK.Wwise.Event stopEvent;
    public float liveTime = 2f;
    public float hitDamage = 1f;
    public float bulletSpeed = 200f;
    public float damage { get { return hitDamage; } }

    public Player currentOwner;
    public Player owner { get { return currentOwner; } set { currentOwner = value; } }

    private float timeDelta;


    public void Fire(Vector3 position, Quaternion orientation, Vector3 baseVelocity, Player _owner)
    {
        transform.position = position;
        transform.rotation = orientation;
        rigidBody.velocity = baseVelocity;
        rigidBody.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.VelocityChange);
        owner = _owner;
        timeDelta = 0f;
    }


    private void FixedUpdate()
    {
        timeDelta += Time.deltaTime;
        if (timeDelta > liveTime)
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        stopEvent.Post(gameObject);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        DestroyMe();
    }
}
