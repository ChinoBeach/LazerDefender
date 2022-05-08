//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{

    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fltProjectileSpeed = 10f;
    [SerializeField] float fltProjectileLifetime = 5f;
    [SerializeField] float fltBaseFiringRate = .2f;

    [Header("AI")]
    [SerializeField] bool bolUseAI;
    [SerializeField] float fltFiringRateVariant = 0f;
    [SerializeField] float fltMinFiringRate = .1f;

    [HideInInspector] public bool bolIsFiring;

    Coroutine firingCoroutine;
   
    void Start()
    {
        if(bolUseAI)
        {
            bolIsFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(bolIsFiring && firingCoroutine == null)
        {
           firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!bolIsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instatnce = Instantiate(projectilePrefab,
                transform.position, Quaternion.identity);

            Rigidbody2D rigidbody = instatnce.GetComponent<Rigidbody2D>();

            if(rigidbody != null)
            {
                rigidbody.velocity = transform.up * fltProjectileSpeed;
            }

            Destroy(instatnce, fltProjectileLifetime);

            float fltTimeToNextProjectile = Random.Range(
                fltBaseFiringRate - fltFiringRateVariant,
                fltBaseFiringRate + fltFiringRateVariant);

            fltTimeToNextProjectile = Mathf.Clamp(fltTimeToNextProjectile, 
                fltMinFiringRate, float.MaxValue);
            
            yield return new WaitForSeconds(fltTimeToNextProjectile);
        }
    }
}
