using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceillamp : MonoBehaviour
{
    private Light light;

    private void Start()
    {
        light = transform.GetChild(1).GetComponent<Light>();
    }

    public void Turn(bool on)
    {
        light.enabled = on;
    }
}
