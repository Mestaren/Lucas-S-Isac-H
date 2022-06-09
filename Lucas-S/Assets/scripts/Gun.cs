
using UnityEngine;

public class Gun : MonoBehaviour
    //gjord av isac
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

   
    void Update()
    {
        //Lägger till tid mellan skott samt aktiverar "void Shoot" 
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    //Denna biten fixar allt som händer NÄR ett skott skjuts
    void Shoot()
    {
        //Aktiverar partikel-systemet
        muzzleFlash.Play();
        //Skickar ut en raycast
        RaycastHit hit;

        //Om det som skottet kolliderar med har taggen Target så gör den skada
     if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Om ett objekt med taggen Target träffas så minskar deras hälsa med 10 och så knuffas den bakåt.
           Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            
            //Lägger til "hitmarkers" där skottet landar, försvinner efter 2 sekunder in-game för att inte döda datorn som kör spelet
           GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }
}
//Isac:
// Vapenkoden som vi fick skickad till oss, inget jag själv har mekat med.