using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : PickableItems
{
   public List<Camera> cameras;
   public int currentCameraIndex;
   public bool canChangeCamera;
   private bool _isUsing;

   private void Start()
   {
   }


   private void Update()
   {
      if (_isUsing && Input.GetKeyDown(KeyCode.Space))
      {
         ChangeCamera();   
      }

      if (Input.GetKeyDown(KeyCode.Escape))
      {
         TurnOffMonitor();
         // LightManager.Instance.TurnOffLights();
      }
   }

   void TurnOffMonitor()
   {
      _isUsing = false;
      
      for (int i = 0; i < cameras.Count; i++)
      {
         cameras[i].enabled = false;
      }

      cameras[0].enabled = true;
      
      PlayerCamera.Instance.MoveCameraBack();

   }

   void OpenMonitor()
   {
      cameras[0].enabled = false;
      cameras[1].enabled = true;
   }
   
   void ChangeCamera()
   {
      if (!canChangeCamera)
      {
         return;
      }
      canChangeCamera = true;
      
      cameras[currentCameraIndex].enabled = false;

      if (currentCameraIndex + 1 < cameras.Count)
      {
         currentCameraIndex += 1;

         if (currentCameraIndex == 3)
         {
            Events CCTVEvent = new Events
            {
               id = 0,
               name = "CCTV Checking",
               description = "Go check the CCTV",
            };
            Storyline.Instance.CompleteEvent(CCTVEvent);
         }
      }
      else
      {
         currentCameraIndex = 1;
      }

      cameras[currentCameraIndex].enabled = true;
   }

   public override void GetPicked(Transform parentTransform)
   {
      _isUsing = true;
      
      PlayerCamera.Instance.MoveCameraByItem(new Vector3(0.03f, 0.32f, 0.79f) , Vector3.up * -180, 0.25f, transform);

      Invoke(nameof(OpenMonitor), 0.35f);
      
      if (currentCameraIndex == 0)
      {
         currentCameraIndex = 1;
      }
      LightManager.Instance.TurnOnLights();
   }

   public void UpdateQuest()
   {
      
   }
}
