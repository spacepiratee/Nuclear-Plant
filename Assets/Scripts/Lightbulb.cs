using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class Lightbulb : MonoBehaviour
{
    private Light light;
    private bool canFlicker;

    private float initialIntensity;
    
    [SerializeField] private float firstEndValue;
    [SerializeField] private float secondEndValue;
    [SerializeField] private float firstDuration;
    [SerializeField] private float secondDuration;
    private void Start()
    {
        light = GetComponent<Light>();
        initialIntensity = light.intensity;

        canFlicker = true;
    }

    private void OnDisable()
    {
        canFlicker = false;
        StopCoroutine(nameof(Flicker));
        light.intensity = initialIntensity;
    }

    IEnumerator Flicker()
    {
        canFlicker = false;
        
        firstEndValue = Random.Range(1f, 6f);
        secondEndValue = Random.Range(8f, 15f);
            
        firstDuration = Random.Range(0.1f, 0.2f);
        secondDuration = Random.Range(0.1f, 0.2f);

        light.DOIntensity(firstEndValue, firstDuration).OnComplete(() =>
        {   
            light.DOIntensity(secondEndValue, secondDuration).SetLoops(20, LoopType.Yoyo);
        });
        
        yield return new WaitForSeconds(3);
        
        canFlicker = true;
    }
   
    void Update()
    {
        if (canFlicker)
        {
            StartCoroutine(Flicker());
        }
    }
}
