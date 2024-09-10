using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickup Object", menuName = "SO/Pickup Object")]
public class PickupObject : ScriptableObject
{
    public string objectName;
    public Vector3 localPosition;
    public Quaternion localRotation;
    
}
