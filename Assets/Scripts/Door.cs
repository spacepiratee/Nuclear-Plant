using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : PickableItems
{
    enum Type
    {
        NeedKey,
        NoKey,
    }
    [SerializeField] private Type doorType;
    private bool _closed;

    [Header("Components")]
    private BoxCollider _boxCollider;

    [SerializeField] private WorldCanvas worldCanvas;
    

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _closed = true;
    }

    public void Interact()
    {
        if (_closed)
        {
            if (doorType == Type.NoKey)
            {
                OpenDoor();
            }
            else
            {
                CheckForKeys();
            }
        }
        else
        {
            CloseDoor();
        }
    }

    void CheckForKeys()
    {
        var findKey = PlayerInventory.Instance.GetItem().Find(t => t.GetComponent<Keycard>()).GetComponent<Keycard>();
        if (!findKey)
        {
            return;
        }
        findKey.GetUsed();
        OpenDoor();
    }
    
    void OpenDoor()
    {
        _boxCollider.isTrigger = true;
        _closed = false;
        var direction = (PlayerCollisionDetection.Instance.transform.position -  transform.position).normalized;
        if (direction.x < 0)
        {
            // Debug.Log(direction.sqrMagnitude);
            transform.DOLocalRotate(new Vector3(0, -30, 0), 0.5f, RotateMode.FastBeyond360).OnComplete(
                () =>
                {
                    _boxCollider.isTrigger = false;
                });
        }
        else
        {
            // Debug.Log(direction.sqrMagnitude);
            transform.DOLocalRotate(new Vector3(0, 240, 0), 0.5f, RotateMode.FastBeyond360).OnComplete(
                () =>
                {
                    _boxCollider.isTrigger = false;
                });
        }
           

    }

    void CloseDoor()
    {
        _boxCollider.isTrigger = true;
        _closed = true;
        transform.DOLocalRotate(Vector3.up * 90, 1f).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            _boxCollider.isTrigger = false;
        });
    }

    public override void GetPicked(Transform parentTransform)
    {
        Interact();
    }

    public override void GetPointedOver()
    {
        worldCanvas.SetCanvas(true);
    }

    public override void NotGettingPointed()
    {
        worldCanvas.SetCanvas(false);
    }
}
