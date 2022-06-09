using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    [Header("camtilt")]
    [SerializeField] playerMovement playerMovement;

    public float mouseSensetivity = 100f;
    public Transform playerBody;
    float Xrotation = 0f;
    float Yrotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity;

        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Xrotation, Yrotation, playerMovement.tilt);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
//Isac:
//All denna kod är kopierad från videon, dock så var jag tvungen att ta bort tidens påverkan ifrån transform.localRotation för att få slo-mo att fungera, då man inte vill att kamerans sensitivitet ska påverkas av tiden.