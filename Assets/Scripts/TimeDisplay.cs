using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;


public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI am;
    [SerializeField] private TextMeshProUGUI hour;
    [SerializeField] private TextMeshProUGUI month;
    [SerializeField] private TextMeshProUGUI year;


    private void Update()
    {
        hour.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
        month.text = DateTime.Now.ToString("MMM");
        year.text = DateTime.Now.Day + " " + DateTime.Now.Year;
    }
}
