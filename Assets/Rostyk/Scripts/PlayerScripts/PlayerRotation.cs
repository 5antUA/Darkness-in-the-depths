using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float _sensitive = 100.0f;

    private float rotationX;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Camera playerCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * _sensitive;
        float rotY = Input.GetAxis("Mouse Y") * _sensitive;

        rotationX -= rotY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotX);
    }
}
