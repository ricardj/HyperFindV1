using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPanelController : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        GameObject devPanel = Resources.Load("DevPanel") as GameObject;
        GameObject instantiatedDevPanel = Instantiate(devPanel);
        DontDestroyOnLoad(instantiatedDevPanel);
    }


    public void Update()
    {
        if(Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);

        }
    }
}
