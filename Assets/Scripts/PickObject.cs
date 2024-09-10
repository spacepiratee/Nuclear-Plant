using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public PickupObject pickupObject;
    private Collider collider;
    private Rigidbody rb;


    private void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    public void GetPickedUp(Transform parent)
    {
        collider.enabled = false;
        rb.useGravity = false;
        
        
        transform.SetParent(parent);
            
            
        transform.localPosition = pickupObject.localPosition;
        transform.localRotation = pickupObject.localRotation;
    }
}
