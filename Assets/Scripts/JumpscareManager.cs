using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareManager : MonoBehaviour
{
    public static JumpscareManager Instance { get; private set; }

    [Header("First Jumpscare")]
    public GameObject starkie;
    public Lightbulb[] lights;
    public GameObject jumpScareBox1;
    
    private void Awake()
    {
        Instance = this;
    }


    public void FirstJumpscare() // after fixing the leaked pipe
    {
       Invoke(nameof(JumpScare), 3);
    }

    public void JumpScare()
    {
        starkie.SetActive(true);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
        
        Invoke(nameof(CompleteFirstJumpscare), 3f);
    }

    void CompleteFirstJumpscare()
    {
        starkie.SetActive(false);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }
    }
    
    
}
