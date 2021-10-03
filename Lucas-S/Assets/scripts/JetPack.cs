using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    CharacterController CC;
    playerMovement PM;

    void Start()
    {
        CC = (CharacterController)GetComponent<CharacterController>();
        PM = (playerMovement)GetComponent<playerMovement>();
    }


    void Update()
    {
      if (Input.GetKey(KeyCode.F))
        {
            Vector3 velocity = new Vector3(0, 10, 0);
            PM.velocity(velocity);
        }
    }
}
