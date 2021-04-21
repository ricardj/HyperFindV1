using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager get;
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


    public void LoadLevel(int levelIndex,Action endCallback)
    {
        LoadingManager.get.
        StartCoroutine(LoadYourAsyncScene(levelIndex, endCallback));
    }

    IEnumerator LoadYourAsyncScene(int levelIndex,Action endCallback)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_" + levelIndex);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }
        if(endCallback != null)
            endCallback.Invoke();
        asyncLoad.allowSceneActivation = true;
        
    }
}
