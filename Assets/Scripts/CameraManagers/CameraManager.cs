using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
            DontDestroyOnLoad(get);
        }
        else if (get != this)
            Destroy(gameObject);
    }
}
