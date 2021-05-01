using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneManager : MonoBehaviour
{

    public static CreditsSceneManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
        }
        else if (get != this)
            Destroy(gameObject);
    }


    public void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SceneChangeManager.get.LoadLevel(AvailableScenes.MAIN_SCREEN);
        }
    }

}
