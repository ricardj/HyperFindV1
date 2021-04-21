using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigureInterfaceCameras();
    }

    public void ConfigureInterfaceCameras()
    {
        Camera mainCamera = Camera.main;
        GetComponentsInChildren<Canvas>().ToList().ForEach(x =>
        {
            x.worldCamera = mainCamera;
        });
    }

    
}
