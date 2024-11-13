using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   public static PlayerCamera Instance { get; private set; }
   
   [Header("Sensitivity")]
   [SerializeField] private float sensX;
   [SerializeField] private float sensY;

   [SerializeField] private Transform orientation;
   [SerializeField] private Transform playerObject;
   [SerializeField] private Transform cameraPos;

   [Header("Rotation")]
   [SerializeField] public  float xRotation;
   [SerializeField] public float yRotation;

   [Header("Virtual Camera")] 
   private CinemachineVirtualCamera _virtualCamera;
   
   public NoiseSettings runNoise;
   public NoiseSettings idleNoise;
   
   public bool canRotate;

   private Transform parent;
   
   [SerializeField] private AnimationCurve animationCurve;
   private Vector3 cameraTransform;
   private Vector3 cameraRotation;
   
   
  
   private void Awake()
   {
      Instance = this;
   }

   private void Start()
   {
      _virtualCamera = GetComponent<CinemachineVirtualCamera>();
      Application.targetFrameRate = 360;
      Cursor.lockState = CursorLockMode.Locked;

      parent = transform.parent;
   }
   
 
   
   public void MoveCameraByItem(Vector3 pos, Vector3 rotation, float dur, Transform newParent)
   {
      isMovingByCode = true;
      transform.SetParent(newParent);
        
      cameraTransform = transform.localPosition;
      cameraRotation = transform.eulerAngles;
        
      transform.DOLocalRotate(rotation, dur).SetEase(animationCurve);
      transform.DOLocalMove(pos, dur).SetEase(animationCurve);
   }

   public void MoveCameraBack()
   {
      transform.DOLocalRotate(cameraRotation, 0.5f).SetEase(animationCurve);
      transform.DOLocalMove(cameraTransform, 0.5f).SetEase(animationCurve).OnComplete(ResetParent);
   }

   public void ResetParent()
   {
      transform.SetParent(parent);
      isMovingByCode = false;
   }

   public bool isMovingByCode;
   
   private void Update()
   {
      if (!isMovingByCode)
      {
         float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
         float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

         yRotation += mouseX;
         xRotation -= mouseY;
    

         xRotation = Mathf.Clamp(xRotation, -90, 90);

         if (canRotate)
         {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
         }
      
      
         orientation.rotation = Quaternion.Euler(0, yRotation, 0);
         playerObject.rotation = Quaternion.Euler(0, yRotation, 0);
      
         cameraPos.rotation = Quaternion.Euler(0, yRotation, 0);
      }
     
     
      CheckForHeadBob();

   }


   void CheckForHeadBob()
   {
      var movement = PlayerMovement.Instance._moveDirection;

      if (movement == Vector3.zero)
      {
         _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = idleNoise;
      }
      else
      {
         _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = runNoise;
      }
   }

  
  
 
   
   
}
