using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class CCTV : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private Camera _camera;
    public Camera GetCamera() { return _camera; }
    public CinemachineVirtualCamera GetVirtualCamera() { return _virtualCamera; }
    
    
    private bool canRotate;
    
    [SerializeField] private float minRotationY;
    [SerializeField] private float maxRotationY;
    [SerializeField] private float rotateDuration;


    [SerializeField] private AnimationCurve curve;

    [SerializeField] private int randomNumber;
    
    private void Start()
    {
        canRotate = true;
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _camera = GetComponent<Camera>();
        _camera.enabled = false;
        randomNumber = Random.Range(1, 3);
    }

   

    private void Update()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        if (canRotate)
        {
            if (randomNumber == 1)
            {
                canRotate = false;
            
                var rotationLeft = new Vector3(transform.eulerAngles.x, minRotationY, transform.eulerAngles.z);
                transform.DORotate(rotationLeft, rotateDuration).SetEase(curve);

                yield return new WaitForSeconds(rotateDuration + 2);
        
                var rotationRight = new Vector3(transform.eulerAngles.x, maxRotationY, transform.eulerAngles.z);
                transform.DORotate(rotationRight, rotateDuration).SetEase(curve);
        
                yield return new WaitForSeconds(rotateDuration + 2);

                canRotate = true;
            }
            else
            {
                canRotate = false;
            
                var rotationRight = new Vector3(transform.eulerAngles.x, maxRotationY, transform.eulerAngles.z);
                transform.DORotate(rotationRight, rotateDuration).SetEase(curve);

                yield return new WaitForSeconds(rotateDuration + 2);
                
                var rotationLeft = new Vector3(transform.eulerAngles.x, minRotationY, transform.eulerAngles.z);
                transform.DORotate(rotationLeft, rotateDuration).SetEase(curve);
                
                yield return new WaitForSeconds(rotateDuration + 2);

                canRotate = true;
            }
            
        }
        
       

    }
   
}
