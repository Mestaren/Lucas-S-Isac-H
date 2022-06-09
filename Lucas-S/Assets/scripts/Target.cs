
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
//Isac:
//Detta script ger fienden en best�md m�ngd h�lsa som minskar om den blir tr�ffad av ett skott.