using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObjectController : MonoBehaviour
{
    [Header("Configuration values")]
    public bool selectable;


    //flag values
    bool mouseDown;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }


    public void Update()
    {
        if(mouseDown && selectable)
        {
            Vector3 mousePosition = Input.mousePosition;
            

            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
        }
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
