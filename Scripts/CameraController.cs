using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Transform gimbal;
    public bool lookAt = true;
    public Vector3 offset = Vector3.zero;
    public void Follow(Transform _gimbal, Transform _target)
    {
        target = _target;
        gimbal = _gimbal;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) return;
        if (lookAt)
        {
            transform.LookAt(target);
            transform.rotation = target.rotation;
        }
        transform.position = gimbal.position + offset;
    }
}
