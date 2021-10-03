using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public float maxFuel = 4f;
    public float thrustForce = 50f;
    public Rigidbody rigid;
    public Transform groundedTransform;
    public ParticleSystem effect;

    private float curFuel;

    void Start()
    {
        curFuel = maxFuel;
    }


    void Update()
    {
        if (Input.GetAxis("Jump") > 0f && curFuel > 0f)
        {
            curFuel -= Time.deltaTime;
            rigid.AddForce(rigid.transform.up * thrustForce, ForceMode.Impulse);
            effect.Play();

            Debug.Log("fly");
        }
        else if(Physics.Raycast(groundedTransform.position, Vector3.down, 50f, LayerMask.GetMask("ground")) && curFuel < maxFuel)
        {
            curFuel += Time.deltaTime;
            effect.Stop();
        }
        else
        {
            effect.Stop();
        }
    }
}
