using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance { get; private set; }
    
    [SerializeField] private List<Ceiling> ceilings;
    [SerializeField] private Elevator elevator;

    [SerializeField] private Light directionalLight;
    private void Awake()
    {
        Instance = this;
        directionalLight.enabled = false;
    }

    public void TurnOnLights() // when use CCTV
    {
        foreach (var ceiling in ceilings)
        {
            ceiling.TurnLights(true);
        }
    }
    
    public void TurnOffLights() // when use CCTV
    {
        foreach (var ceiling in ceilings)
        {
            ceiling.TurnLights(false);
        }
        ceilings[elevator.currentFloor].TurnLights(true);
    }
}
