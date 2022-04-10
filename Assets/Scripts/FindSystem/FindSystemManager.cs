using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class FindSystemManager : Singleton<FindSystemManager>
{
    [Header("Configuration values")]
    public ObjectsListSO currentObjectsList;
    public List<ObjectsListSO> availableObjectsList;

    public List<SelectableObjectController> selectableObjects;

    [Header("Events")]
    public SelectableObjectEvent OnObjectFoundEvent;
    public UnityEvent OnAllObjectsFoundEvent;

    //Debug flag values
    int objectsFound = 0;




    public void Start()
    {
        //Setup current List
        SetupCurrentSelectableObjectsList();

        //Find all selectable objects in list
        SetupFinalSelectableObjects();
    }

    private void SetupCurrentSelectableObjectsList()
    {
        currentObjectsList = availableObjectsList[Random.Range(0, availableObjectsList.Count)];
    }

    private void SetupFinalSelectableObjects()
    {
        FindObjectsOfType<SelectableObjectController>().ToList().ForEach(x =>
        {
            x.selectable = IsObjectSelectable(x.objectPack);
            if (x.selectable)
            {
                selectableObjects.Add(x);
            }
            x.OnObjectCorrectlySelected.AddListener(OnObjectFound);
        });
    }

    public void OnObjectFound(SelectableObjectSO foundObject)
    {

        OnObjectFoundEvent.Invoke(foundObject);
        objectsFound++;

        if(objectsFound >= currentObjectsList.objectsList.Count)
        {
            OnAllObjectsFoundEvent.Invoke();
        }
    }

    public bool IsObjectSelectable(SelectableObjectSO objectId)
    {
        return currentObjectsList.IsObjectInList(objectId);
    }
}
