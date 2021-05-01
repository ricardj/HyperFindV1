using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SceneManager : MonoBehaviour
{

    public static Level1SceneManager get;
    void Awake()
    {
        if (get == null)
        {
            get = this;
        }
        else if (get != this)
            Destroy(gameObject);
    }



    public void Start()
    {
        FindSystemManager.get.OnAllObjectsFoundEvent.AddListener(EndGame);
    }

    public void EndGame()
    {
        SceneChangeManager.get.LoadLevel(AvailableScenes.CREDITS, null);
    }
}
