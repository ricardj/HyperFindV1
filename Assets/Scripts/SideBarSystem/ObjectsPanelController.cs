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
            string currentObjectId = currentObjectsList.objectsList[i];
            newLabelList.GetComponentInChildren<TextMeshProUGUI>().text = "- " + currentObjectId;
            LabelListController labelListController = newLabelList.GetComponentInChildren<LabelListController>();
            labelListController.objectId = currentObjectId;
            listReferences.Add(labelListController);            
        }
    }

    public void DestroyChild(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void RemoveObject(SelectableObjectPack objectPack)
    {
        LabelListController labelListController = listReferences.Find(x => x.objectId == objectPack.id);
        if(labelListController != null)
        {
            listReferences.Remove(labelListController);
            Destroy(labelListController.gameObject);
        }
    }
}
