using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorUI : MonoBehaviour
{
    public static CursorUI Instance { get; private set; }
    private Image cursorImage;

    [SerializeField] private Sprite normalCursor;
    [SerializeField] private Sprite highlightedCursor;
    
    private void Awake()
    {
        Instance = this;
        cursorImage = GetComponent<Image>();
    }

    public void SetNormal()
    {
        cursorImage.sprite = normalCursor;
    }

    public void SetHighlighted()
    {
        cursorImage.sprite = highlightedCursor;
    }
}
