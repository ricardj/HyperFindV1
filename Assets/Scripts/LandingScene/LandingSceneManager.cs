using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingSceneManager : MonoBehaviour
{
    public static LandingSceneManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
        }
        else if (get != this)
            Destroy(gameObject);
    }

    public void NewGame()
    {
        SceneChangeManager.get.LoadLevel(AvailableScenes.LEVEL_1, null);
    }

    public void Credits()
    {
        SceneChangeManager.get.LoadLevel(AvailableScenes.CREDITS, null);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
