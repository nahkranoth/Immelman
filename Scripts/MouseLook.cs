using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;
        float mouseY = Input.mousePosition.y / Screen.height;

        rotY = (mouseX - 0.5f) * mouseSensitivity;
        rotX = (-mouseY - 0.5f) * mouseSensitivity;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle);

        Vector3 myEuler = transform.parent.localRotation.eulerAngles;
        Quaternion localRotation = Quaternion.Euler(rotX + myEuler.x, rotY + myEuler.y, myEuler.z);

        transform.rotation = transform.parent.localRotation;
    }
}