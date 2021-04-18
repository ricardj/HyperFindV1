using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventChannelSO : ScriptableObject
{
    public UnityAction mainEvent;


    public void RaiseEvent()
    {
        mainEvent.Invoke();
    }
}
