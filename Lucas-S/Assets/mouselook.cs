using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensetivity = 100f;
    public Transform playerBody;
    float Xrotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
