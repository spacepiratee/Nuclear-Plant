using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : PickableItems
{
    [SerializeField] private PickupObject pickupObject;
    [SerializeField] private Light light;
    private bool isOn;
    
    private Collider collider;
    private Rigidbody rb;


    private void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                isOn = false;
                light.enabled = false;
            }
            else
            {
                isOn = true;
                light.enabled = true;
            }
        }
    }

    public override void GetPicked(Transform parentTransform)
    {
        collider.enabled = false;
        rb.useGravity = false;
        
        
        transform.SetParent(parentTransform);
            
            
        transform.localPosition = pickupObject.localPosition;
        transform.localRotation = pickupObject.localRotation;
    }
}
