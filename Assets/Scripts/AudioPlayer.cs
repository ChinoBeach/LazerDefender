using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float fltShootingVolume = .4f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float fltExplosionVolume = .75f;

 /* I am choosing to not use this because I would like diffrent background musics for each scene
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        int intInstanceCount = FindObjectsOfType(GetType()).Length;
        if(intInstanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    */
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, fltShootingVolume);
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionClip, fltExplosionVolume);
    }

   void PlayClip(AudioClip clip, float fltVolume)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,
              Camera.main.transform.position, fltVolume);
        }
    }


}
