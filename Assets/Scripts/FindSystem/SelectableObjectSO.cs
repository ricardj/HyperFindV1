using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NEw selectable object", menuName = "Hyper Scriptables/New selectable object")]
public class SelectableObjectSO : ScriptableObject
{
    public string id = "Normal Object";

    internal string GetObjectName()
    {
        return id;
    }
}
