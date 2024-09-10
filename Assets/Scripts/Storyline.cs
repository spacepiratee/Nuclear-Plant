using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;

public class Storyline : MonoBehaviour
{
    public static Storyline Instance { get; private set; }
    
    public EventList eventList;
    public Events currentEvent;
    public int currentEventIndex;

    public event EventHandler OnOpenMonitor;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       GetData();
       currentEvent = eventList.events[0];
       Invoke(nameof(StartEvent), 5f);
    }

    [ContextMenu("Start Event")]
    public void StartEvent()
    {
        ObjectivePanel.Instance.GetObjective(eventList.events[currentEventIndex]);
    }

    public void CompleteEvent(Events completedEvent)
    {
        if (currentEvent.name == completedEvent.name)
        {
            Debug.Log("Complete " + currentEvent.name + " quest");
            if (currentEvent.id == 1)
            {
                JumpscareManager.Instance.jumpScareBox1.SetActive(true);
            }
            UpdateEvent();
        }
        
        
    }
    
    [ContextMenu("Update Event")]
    public void UpdateEvent()
    {
        currentEventIndex += 1;
        currentEvent = eventList.events[currentEventIndex];
        Invoke(nameof(StartEvent), 3);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    [ContextMenu("Write Data")]
    public void WriteData()
    {
        string path = Application.persistentDataPath + "/Events.json";
        
        File.WriteAllText(path, JsonUtility.ToJson(eventList, true));
    }

    
    public void GetData()
    {
        string path = Application.persistentDataPath + "/Events.json";

        var data = File.ReadAllText(path);
        EventList eList = JsonUtility.FromJson<EventList>(data);
        foreach (var e in eList.events)
        {
            Events events = e;
            eventList.events.Add(events);
        }
    }
    
    
}

[Serializable]
public class EventList
{
    public List<Events> events;
}

[Serializable]
public class Events
{
    public int id;
    public string name;
    [TextArea(2, 5)] public string description;
    public bool status;

}

[CustomEditor(typeof(Storyline))]
public class StoryLineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        Storyline storyline = (Storyline)target;

        if (GUILayout.Button("Start Event"))
        {
            storyline.StartEvent();
        }
        
        if (GUILayout.Button("Write Data"))
        {
            storyline.WriteData();
        }
    }
}