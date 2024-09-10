using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ObjectivePanel : MonoBehaviour
{
    public static ObjectivePanel Instance { get; private set; }
    
    [SerializeField] private Events currentObjective;
    
    private RectTransform _objectivePopupRect;
    private TextMeshProUGUI _objectivePopupText;

    private CanvasGroup _canvasGroup;
    private TextMeshProUGUI _objectiveDetail;

    private bool _isPaused;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
        _objectiveDetail = _canvasGroup.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        
        _objectivePopupRect = transform.GetChild(1).GetComponent<RectTransform>();
        _objectivePopupText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    
    
    public void GetObjective(Events events)
    {
        currentObjective = events;

        _objectivePopupText.text = "New objective, press <color=#FFCB4C>[TAB]</color> to see";
        _objectiveDetail.text = currentObjective.description;
        
        _objectivePopupText.DOFade(1, 0.25f).OnComplete(() =>
        {
            Invoke(nameof(SetOffObjectiveText), 2f);
        });
    }

    public void OpenObjective()
    {
        _isPaused = true;
        _canvasGroup.DOFade(1, 0.5f).SetUpdate(true);
        Time.timeScale = 0;
    }

    public void CloseObjective()
    {
        _canvasGroup.DOFade(0, 0.5f).SetUpdate(true).OnComplete(() =>
        {
            Time.timeScale = 1;
            _isPaused = false;
        });
        
        
    }

    void SetOffObjectiveText()
    {
        _objectivePopupText.DOFade(0, 0.25f);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_isPaused)
            {
                CloseObjective();
            }
            else
            {
                OpenObjective();
            }
        }
    }
    
    
}
