using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

[Serializable]
public class SelectableObjectEvent : UnityEvent<SelectableObjectPack> { }

public class SelectableObjectController : MonoBehaviour
{
    [Header("Configuration values")]
    public SelectableObjectPack objectPack;
    


    [Header("Events")]
    public SelectableObjectEvent OnObjectCorrectlySelected;



    //flag values
    bool mouseDown;
    Camera mainCamera;

    [HideInInspector]
    public bool selectable;

    private void Start()
    {
        mainCamera = Camera.main;
        
    }


    public void Update()
    {
        if(mouseDown && selectable)
        {     
            OnObjectSelected();
            mouseDown = false;

            //Vector3 mousePosition = Input.mousePosition;
            //mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            //mousePosition.z = transform.position.z;
            //transform.position = mousePosition;
        }
    }


    public void OnObjectSelected()
    {
        transform.DOScale(Vector3.zero, 0.3f);
        OnObjectCorrectlySelected.Invoke(objectPack);
    }

    public void OnMouseDown()
    {
        mouseDown = true;
        Debug.Log("Mouse down");
    }
    public void OnMouseUp()
    {
        mouseDown = false;        
    }
}

[Serializable]
public class SelectableObjectPack
{
    public string id = "Normal Object";
    
}
