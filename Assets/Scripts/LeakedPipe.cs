using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LeakedPipe : PickableItems
{
    private Transform valve;
    private ParticleSystem waterParticles;

    [SerializeField] private AnimationCurve animationCurve;

    private Vector3 cameraTransform;
    private Vector3 cameraRotation;
    private void Start()
    {
        valve = transform.GetChild(0);
    }


    public void RotateValve()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        var rotation = Vector3.forward * 135;
        
        valve.DOLocalRotate(rotation, 0.5f, RotateMode.FastBeyond360).SetRelative().SetEase(animationCurve);
        
        yield return new WaitForSeconds(1);
        
        valve.DOLocalRotate(rotation, 0.5f, RotateMode.FastBeyond360).SetRelative().SetEase(animationCurve);
        
        yield return new WaitForSeconds(1);

        valve.DOLocalRotate(rotation, 0.5f, RotateMode.FastBeyond360).SetRelative().SetEase(animationCurve);
        
        yield return new WaitForSeconds(1);

        PlayerCamera.Instance.transform.DOLocalRotate(cameraRotation, 0.5f).SetEase(animationCurve);
        PlayerCamera.Instance.transform.DOLocalMove(cameraTransform, 0.5f).SetEase(animationCurve).OnComplete(() =>
        {
            PlayerCamera.Instance.ResetParent();
            Events pipeEvent = new Events
            {
                name = "Pipe Checking"
            };
            Storyline.Instance.CompleteEvent(pipeEvent);
        });
    }

    public void SetCameraToLookValve()
    {
        PlayerCamera.Instance.isMovingByCode = true;
        PlayerCamera.Instance.transform.SetParent(transform);
        
        cameraTransform = PlayerCamera.Instance.transform.localPosition;
        cameraRotation = PlayerCamera.Instance.transform.eulerAngles;
        
        PlayerCamera.Instance.transform.DOLocalRotate(new Vector3(6, 195, 0), 0.5f).SetEase(animationCurve);
        PlayerCamera.Instance.transform.DOLocalMove(new Vector3(0.16f, 1.65f, 0.6f), 0.5f).SetEase(animationCurve);


    }

    public override void GetPicked(Transform parentTransform)
    {
        SetCameraToLookValve();
        Invoke(nameof(RotateValve), 1.25f);
        // RotateValve();
    }
}
