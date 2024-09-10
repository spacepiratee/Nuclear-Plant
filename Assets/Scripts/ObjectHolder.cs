using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    [SerializeField] private float lerpAmount;
    public PickObject pickObject;
    [SerializeField] private PlayerCamera playerCamera;

    private void Update()
    {
        Move();      
    }


    void Move()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,  Quaternion.Euler(playerCamera.xRotation, playerCamera.yRotation, 0), lerpAmount * Time.deltaTime);
    }
    
}
