using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ObjectList",menuName = "New Object List")]
public class ObjectsListSO : ScriptableObject
{
    public List<string> objectsList;

    public bool IsObjectInList(string objectId)
    {
        string foundObject = objectsList.Find(x => x == objectId);
        if (foundObject != null)
            return true;
        return false;
    }
}
