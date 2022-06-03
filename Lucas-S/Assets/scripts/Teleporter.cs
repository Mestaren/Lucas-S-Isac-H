using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour

    //gjort av Lucas
{
    public Transform TeleportTarget;
    public GameObject FPplayer;

    private void OnTriggerEnter(Collider collision)
    {
        FPplayer.transform.position = TeleportTarget.transform.position;
    }
}
