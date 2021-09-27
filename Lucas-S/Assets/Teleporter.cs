using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject FPplayer;

    private void OnTriggerEnter(Collider collision)
    {
        FPplayer.transform.position = TeleportTarget.transform.position;
    }
}
