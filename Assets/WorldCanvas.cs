using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCanvas : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        cameraTransform = Camera.main.transform;
    }


    public void SetCanvas(bool set)
    {
        _canvas.enabled = set;
    }
    private void Update()
    {
        transform.eulerAngles = cameraTransform.eulerAngles;
    }
}
