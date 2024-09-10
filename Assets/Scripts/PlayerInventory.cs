using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    [SerializeField] private List<PickableItems> items;

    public void UseItem(PickableItems pickable)
    {
        items.Remove(pickable);
    }
    
    public List<PickableItems> GetItem()
    {
        return items;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(PickableItems pickable)
    {
        items.Add(pickable);
    }
    
    
}
