using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
        }
        else if (get != this)
            Destroy(gameObject);
    }

    public void LoadLevel(AvailableScenes availaibleScene, Action endCallback = null)
    {
        int levelIndex = AvailableSceneToIndex(availaibleScene);
        StartCoroutine(LoadYourAsyncScene(levelIndex, endCallback));
    }

    IEnumerator LoadYourAsyncScene(int levelIndex, Action endCallback)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }
        if (endCallback != null)
            endCallback.Invoke();
        asyncLoad.allowSceneActivation = true;
    }

    public int AvailableSceneToIndex(AvailableScenes availableScenes)
    {
        int returnIndex = 0;
        switch (availableScenes)
        {
            case AvailableScenes.MAIN_SCREEN:
                returnIndex = 0;
                break;
            case AvailableScenes.LEVEL_1:
                returnIndex = 1;
                break;
            case AvailableScenes.CREDITS:
                returnIndex = 2;
                break;
            default:
                break;
        }

        return returnIndex;
    }
}

public enum AvailableScenes
{
    MAIN_SCREEN,
    LEVEL_1,
    CREDITS
}
