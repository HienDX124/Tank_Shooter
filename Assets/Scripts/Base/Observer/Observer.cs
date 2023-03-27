using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : SingletonMonoBehaviour<Observer>
{
    private Dictionary<EventID, UnityAction<object>> eventActionDict;
    private Dictionary<EventID, UnityAction<object>> EventActionDict
    {
        get
        {
            if (eventActionDict == null) eventActionDict = new Dictionary<EventID, UnityAction<object>>();
            return eventActionDict;
        }
    }

    public void RegistListener(EventID eventID, UnityAction<object> action)
    {
        if (EventActionDict.ContainsKey(eventID))
            EventActionDict[eventID] += action;
        else
            EventActionDict.Add(eventID, action);
    }

    public void RemoveListenner(EventID eventID, UnityAction<object> action)
    {
        if (EventActionDict.ContainsKey(eventID))
            EventActionDict[eventID] -= action;
    }

    public void PostEvent(EventID eventID, object parameter)
    {
        if (!EventActionDict.ContainsKey(eventID))
        {
            Debug.LogWarning($"There's no any object regist event {eventID}");
            return;
        }
        if (EventActionDict[eventID] != null)
            EventActionDict[eventID](parameter);
    }
}
