using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    //Flag values
    public static bool loadingScene = false;

    public static SceneChangeManager get;

    public UnityEvent OnSceneChanged;
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
        if(!loadingScene)
        {
            loadingScene = true;

            yield return LoadLoadingScene();

            yield return ActivateLoadingAnimationAndLoadNextScene(levelIndex);



            loadingScene = false;
        }
    }

    public IEnumerator ActivateLoadingAnimationAndLoadNextScene(int levelIndex)
    {
        LoadingManager loadingManager = FindObjectOfType<LoadingManager>();
        bool animationComplete = false;
        loadingManager.Show(() => animationComplete = true);


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f || !animationComplete)
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
        OnSceneChanged.Invoke();
        if (loadingManager != null)
            loadingManager.Hide();
    }

    public IEnumerator LoadLoadingScene()
    {
        yield return null;

        AsyncOperation loadingSceneAsyncLoad = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        loadingSceneAsyncLoad.allowSceneActivation = true;

        while (loadingSceneAsyncLoad.progress < 1)
        {
            yield return loadingSceneAsyncLoad;
        }
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
