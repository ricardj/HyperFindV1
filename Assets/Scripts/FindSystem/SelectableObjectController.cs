using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

[Serializable]
public class SelectableObjectEvent : UnityEvent<SelectableObjectSO> { }

public class SelectableObjectController : MonoBehaviour
{
    [Header("Configuration values")]
    public SelectableObjectSO objectPack;



    [Header("Events")]
    public SelectableObjectEvent OnObjectCorrectlySelected;



    //flag values
    bool mouseDown;
    Camera mainCamera;

    [HideInInspector]
    public bool selectable;

    public Transform shadow;

    private void Start()
    {
        mainCamera = Camera.main;

    }


    public void Update()
    {
        if (mouseDown && selectable)
        {
            OnObjectSelected();
            mouseDown = false;

        }
    }


    public void OnObjectSelected()
    {
        transform.DOScale(Vector3.zero, 0.3f).OnComplete(() => transform.gameObject.SetActive(false));
        if (shadow != null)
            shadow.DOScale(Vector3.zero, 0.3f).OnComplete(() => shadow.gameObject.SetActive(false));
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
