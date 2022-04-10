using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneManager : MonoBehaviour
{

    public static CreditsSceneManager get;

    public bool mouseClicked = false;

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
        if (Input.GetMouseButtonDown(0))
        {
            //if (!mouseClicked)
            //{
            //    mouseClicked = true;
                SceneChangeManager.get.LoadLevel(AvailableScenes.MAIN_SCREEN);
            //}
        }
    }

}
