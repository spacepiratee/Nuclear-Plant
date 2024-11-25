using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickableItems : MonoBehaviour
{
   public abstract void GetPicked(Transform parentTransform);
   public abstract void GetPointedOver();
   public abstract void NotGettingPointed();
   
}
