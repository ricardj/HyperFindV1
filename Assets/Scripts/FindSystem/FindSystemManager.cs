using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class FindSystemManager : MonoBehaviour
{
    [Header("Configuration values")]
    public ObjectsListSO currentObjectsList;

    public List<SelectableObjectController> selectableObjects;

    [Header("Events")]
    public SelectableObjectEvent OnObjectFoundEvent;
    public UnityEvent OnAllObjectsFoundEvent;

    //Debug flag values
    int objectsFound = 0;


    public static FindSystemManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
        }
        else if (get != this)
            Destroy(gameObject);
    }

    public void Start()
    {
        //Find all selectable objects in list
        FindObjectsOfType<SelectableObjectController>().ToList().ForEach(x =>
        {
            x.selectable = IsObjectSelectable(x.objectPack.id);
            if(x.selectable)
            {
                selectableObjects.Add(x);
            }
            x.OnObjectCorrectlySelected.AddListener(OnObjectFound);
        });        
    }

    public void OnObjectFound(SelectableObjectPack foundObject)
    {

        OnObjectFoundEvent.Invoke(foundObject);
        objectsFound++;

        if(objectsFound >= currentObjectsList.objectsList.Count)
        {
            OnAllObjectsFoundEvent.Invoke();
        }
    }

    public bool IsObjectSelectable(string objectId)
    {
        return currentObjectsList.IsObjectInList(objectId);
    }
}
