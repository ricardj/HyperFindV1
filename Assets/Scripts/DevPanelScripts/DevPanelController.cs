using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevPanelController : MonoBehaviour
{

    public void Update()
    {
        if(Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
}
