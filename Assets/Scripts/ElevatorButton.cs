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
    private Elevator _elevator;

    [SerializeField] private WorldCanvas _worldCanvas;
    
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

    public override void GetPointedOver()
    {
        _worldCanvas.SetCanvas(true);
    }

    public override void NotGettingPointed()
    {
        _worldCanvas.SetCanvas(false);
    }
}
