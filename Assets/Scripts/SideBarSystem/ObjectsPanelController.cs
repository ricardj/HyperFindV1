using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ObjectsPanelController : MonoBehaviour
{
    public ObjectsListSO currentObjectsList;

    public Transform parentList;
    public GameObject labelListPrefab;

    private void Start()
    {
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
        for(int i = 0; i < currentObjectsList.objectsList.Count; i++)
        {
            GameObject newLabelList = Instantiate(labelListPrefab, parentList);
            string currentObject = currentObjectsList.objectsList[i];
            newLabelList.GetComponentInChildren<TextMeshProUGUI>().text = "- " + currentObject;
        }
    }

    public void DestroyChild(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
