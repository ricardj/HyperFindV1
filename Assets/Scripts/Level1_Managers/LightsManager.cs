using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigureCamera();
    }

    public void ConfigureCamera()
    {
        Camera mainCamera = Camera.main;
        GetComponentsInChildren<Canvas>().ToList().ForEach(x =>
        {
            x.worldCamera = mainCamera;
        });
    }
}
