using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentControllersManager : MonoBehaviour
{

    
    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        string prefabName = "M - PersistentManagers";
        GameObject effectsController = Resources.Load(prefabName) as GameObject;
        GameObject instantiatedDevPanel = Instantiate(effectsController);
        DontDestroyOnLoad(instantiatedDevPanel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
