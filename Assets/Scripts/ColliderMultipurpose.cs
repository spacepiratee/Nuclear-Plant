using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class ColliderMultipurpose : MonoBehaviour
{
        
    public UnityEvent unityEvent;
    public float invokeTime;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            Debug.Log("Hit player");
            Invoke(nameof(TriggerEvent), invokeTime);
        }
    }

    void TriggerEvent()
    {
        unityEvent.Invoke();

    }
    
    
}
