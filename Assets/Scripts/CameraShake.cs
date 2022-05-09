using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float fltShakeDurration = 1f;
    [SerializeField] float fltShakeMagnitude = .5f;

    Vector3 initalPosition;
    void Start()
    {
        initalPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float fltElapsedTime = 0f;
        
        while(fltElapsedTime < fltShakeDurration)
        {
            transform.position = initalPosition + (Vector3)Random.insideUnitCircle * fltShakeMagnitude;
            fltElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initalPosition;

    }
   
}
