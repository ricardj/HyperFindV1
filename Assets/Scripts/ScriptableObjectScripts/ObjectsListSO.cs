using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectList", menuName = "New Object List")]
public class ObjectsListSO : ScriptableObject
{
    public List<SelectableObjectSO> objectsList;

    public bool IsObjectInList(SelectableObjectSO selectableObject)
    {
        return objectsList.Contains(selectableObject);
    }
}
