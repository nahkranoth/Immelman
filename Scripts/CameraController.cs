using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Transform gimbal;
    public bool lookAt = true;
    public Vector3 offset = Vector3.zero;


    private float shakeMagnitude = 1.2f;
    private bool isShaking = false;

    public void Follow(Transform _gimbal, Transform _target)
    {
        target = _target;
        gimbal = _gimbal;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!target) return;
        if (lookAt) transform.rotation = target.rotation;
        transform.position = gimbal.position + offset + GetRandomShakePosition();
    }

    private Vector3 GetRandomShakePosition()
    {
        return isShaking ? Random.insideUnitSphere * shakeMagnitude : Vector3.zero;
    }

    public void EnableScreenShake()
    {
        isShaking = true;
    }

    public void DisableScreenShake()
    {
        isShaking = false;
    }

    public void BurstScreenShake()
    {

    }
}
