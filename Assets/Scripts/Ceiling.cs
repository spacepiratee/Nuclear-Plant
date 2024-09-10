using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    [SerializeField] private Ceillamp[] lights;
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void TurnOffMesh()
    {
        _meshRenderer.enabled = false;
    }

    public void TurnOnMesh()
    {
        _meshRenderer.enabled = true;
    }

    public void TurnOffCollider()
    {
        _collider.isTrigger = true;
    }

    public void TurnOnCollider()
    {
        Invoke(nameof(T), 1f);
    }

    public void TurnLights(bool on)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].Turn(on);
        }
       
    }

    void T()
    {
        _collider.isTrigger = false;
    }
}
