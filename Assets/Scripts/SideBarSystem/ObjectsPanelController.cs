using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ObjectsPanelController : MonoBehaviour
{
    
    [Header("Useful references")]
    public Transform parentList;
    public GameObject labelListPrefab;

    //Flag and debug values
    ObjectsListSO currentObjectsList;
    List<LabelListController> listReferences;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    public IEnumerator DelayedStart()
    {
        yield return null;
        FindSystemManager.get.OnObjectFoundEvent.AddListener(RemoveObject);
        ConfigureList();
    }

    public void ConfigureList()
    {
        
        //Destroy all child
        DestroyChild(parentList.gameObject);

        //Instantiate new list
        InstantiateLabels();
    }

    public void InstantiateLabels()
    {
        listReferences = new List<LabelListController>();
        currentObjectsList = FindSystemManager.get.currentObjectsList;
        for(int i = 0; i < currentObjectsList.objectsList.Count; i++)
        {
            GameObject newLabelList = Instantiate(labelListPrefab, parentList);
            LabelListController labelListController = ConfigureNewLabel(i, newLabelList);
            listReferences.Add(labelListController);
        }
    }

    private LabelListController ConfigureNewLabel(int i, GameObject newLabelList)
    {
        LabelListController labelListController = newLabelList.GetComponentInChildren<LabelListController>();
        string currentObjectId = currentObjectsList.objectsList[i].GetObjectName();
        LabelConfiguration labelConfiguration = new LabelConfiguration();
        labelConfiguration.labelText = "- " + currentObjectId;
        labelConfiguration.objectId = currentObjectId;
        labelListController.ConfigureLabel(labelConfiguration);
        return labelListController;
    }

    public void DestroyChild(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void RemoveObject(SelectableObjectSO objectPack)
    {
        LabelListController labelListController = listReferences.Find(x => x.objectId == objectPack.id);
        if(labelListController != null)
        {
            listReferences.Remove(labelListController);
            Debug.Log("Trying to mark the flag");
            labelListController.ShowLabelFinishedFeedback();
        }
    }
}
