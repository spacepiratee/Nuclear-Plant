using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycaster : MonoBehaviour
{
    private RaycastHit _raycastHit;
    
    [SerializeField] private Transform highlight;
    [SerializeField] private ObjectHolder objectHolder;

    [SerializeField] private float maxDistance;
   

    private void Update()
    {
        if (!GetComponent<Camera>().enabled)
        {
            return;
        }
        
        Debug.DrawRay(transform.position, transform.forward * maxDistance);

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out _raycastHit, maxDistance))
        {
            highlight = _raycastHit.transform;
            
            if (highlight.gameObject.CompareTag("Highlightable"))
            {
                Debug.Log("Hit " + highlight.name);
                CursorUI.Instance.SetHighlighted();

                
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
            }
            else
            {
                highlight = null;
                CursorUI.Instance.SetNormal();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (highlight == null)
            {
                return;
            }
            if (highlight.gameObject.GetComponent<PickableItems>() != null)
            {
                var pickableObject = highlight.gameObject.GetComponent<PickableItems>();
                pickableObject.GetPicked(objectHolder.transform);
              
                // if (highlight.gameObject.GetComponent<ElevatorButton>())
                // {
                //     highlight.gameObject.GetComponent<ElevatorButton>().Tween(GetComponent<PlayerCamera>(), transform.localPosition, transform.localRotation, transform.parent);
                // }
                
            }
            
        }
    }
}
