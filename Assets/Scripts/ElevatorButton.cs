using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ElevatorButton : PickableItems
{
    enum Button
    {
        In,
        Out,
    }

    [SerializeField] private Button button;
    [SerializeField] private Transform targetObj;
    private Elevator _elevator;
    private void Start()
    {
        switch (button)
        {
            case Button.In:
                _elevator = transform.parent.GetComponent<Elevator>();
                break;
            case Button.Out:
                _elevator = transform.parent.parent.GetComponent<Elevator>();
                break;
        }
        
        targetObj = transform.GetChild(0);
    }

    public void Tween(PlayerCamera playerCamera, Vector3 originalPos, Quaternion originalRotation, Transform parent)
    {
        switch (button)
        {
            case Button.Out:
                targetObj.SetParent(null);
                playerCamera.canRotate = false;
                
                targetObj.SetParent(parent);

                playerCamera.transform.DOLocalRotateQuaternion(targetObj.transform.localRotation, 0.5f).OnComplete(() =>
                {
                    playerCamera.transform.DOLocalRotateQuaternion(originalRotation, 0.5f);
                });

                playerCamera.transform.DOLocalMove(targetObj.transform.localPosition, 0.5f).OnComplete(() =>
                {
                    //playerCamera.transform.DOShakePosition(0.5f, Vector3.up, 5, 45);
                    playerCamera.transform.DOLocalMove(originalPos, 0.5f).OnComplete(() =>
                    {
                        playerCamera.canRotate = true;
                        targetObj.transform.SetParent(transform);
                        targetObj.SetAsFirstSibling();
                        _elevator.Interact();
                    });
                });
                break;
            case Button.In:
                targetObj.SetParent(null);
                playerCamera.canRotate = false;
                
                targetObj.SetParent(parent);

                playerCamera.transform.DOLocalRotateQuaternion(targetObj.transform.localRotation, 0.5f).OnComplete(() =>
                {
                    playerCamera.transform.DOLocalRotateQuaternion(originalRotation, 0.5f);
                    targetObj.transform.SetParent(transform);
                    targetObj.SetAsFirstSibling();
                });
                
                break;
        }
       
    }

    public override void GetPicked(Transform parentTransform)
    {
        switch (button)
        {
            case Button.Out:
                _elevator.Interact();
                break;
            case Button.In:
                _elevator.Move();
                break;
        }
    }
}
