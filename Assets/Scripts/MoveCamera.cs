using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPos;

    private void Start()
    {
        transform.position = Vector3.up * 0.6f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        transform.position = cameraPos.position;
        //transform.rotation = cameraPos.rotation;
        
        
    }

   
}
