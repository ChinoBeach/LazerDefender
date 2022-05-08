using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int intHealth = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamage());
            //tell damage dealer that it hit something
            damageDealer.Hit();
            Debug.Log("Hit");
        }
    }

     void TakeDamage(int intDamage)
    {
        intHealth -= intDamage;
        Debug.Log("Damage Delt");

        if (intHealth >= 0)
        {
            Destroy(gameObject);
        }
    }
}
