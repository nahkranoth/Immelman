using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private Transform gimbal;
    public bool lookAt = true;
    public Vector3 offset = Vector3.zero;

    private float shakeMagnitude = 1.2f;
    private bool isShaking = false;

    private float rotateCameraRadius = 36f;
    private float mouseSensitivity = 0.5f;

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
            transform.rotation = target.rotation;
            transform.position = gimbal.position + offset + GetRandomShakePosition();
        }
    }

    public void StartRotate()
    {
        lookAt = false;
    }

    public void StopRotate()
    {
        lookAt = true;
    }
    public void RotateCamera(Vector2 mousePosition, Vector3 origin)
    {
        var x = (mousePosition.x - 0.5f) * mouseSensitivity;
        var y = (mousePosition.y - 0.5f) * mouseSensitivity;
        Vector3 pos = origin;
        pos.x = origin.x + rotateCameraRadius;
        transform.position = RotatePointAroundPivot(pos, origin, new Vector3(0f, x, y));
        transform.LookAt(origin);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
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
