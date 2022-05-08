using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int intDamage = 10;

    public int GetDamage()
    {
        return intDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
