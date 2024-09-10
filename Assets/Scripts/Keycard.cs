using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : PickableItems
{
    public void GetUsed()
    {
        PlayerInventory.Instance.AddItem(this);
    }

    public override void GetPicked(Transform parentTransform)
    {
        PlayerInventory.Instance.AddItem(this);
    }
}
