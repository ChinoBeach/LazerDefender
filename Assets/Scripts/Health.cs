using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] int intHealth = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool bolApplyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger");
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamage());
            //play hit effect 
            PlayHitEffect();
            //play the audio
            audioPlayer.PlayExplosionClip();
            //Shake the Camera 
            ShakeCamera();
            //tell damage dealer that it hit something
            damageDealer.Hit();
           // Debug.Log("Hit");
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && bolApplyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void TakeDamage(int intDamage)
    {
        intHealth -= intDamage;
        //Debug.Log("Damage Delt");

        if (intHealth >= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
