using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fltProjectileSpeed = 10f;
    [SerializeField] float fltProjectileLifetime = 5f;

    [SerializeField] float fltFiringRate = .2f;

    Coroutine firingCoroutine;

    public bool bolIsFiring;
    void Start()
    {
        
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

            yield return new WaitForSeconds(fltFiringRate);
        }
    }
}
