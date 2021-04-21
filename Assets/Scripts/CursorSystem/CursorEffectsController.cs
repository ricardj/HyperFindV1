using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEffectsController : MonoBehaviour
{
    public static string prefabName = "M - CursorEffects";
    public GameObject particlesPrefab; 

    [RuntimeInitializeOnLoadMethod]
    public static void Initialize()
    {
        GameObject effectsController = Resources.Load(prefabName) as GameObject;
        GameObject instantiatedDevPanel = Instantiate(effectsController);
        DontDestroyOnLoad(instantiatedDevPanel);
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
           StartCoroutine(MakePressEffect());
    }

    public IEnumerator MakePressEffect()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        GameObject newParticles = Instantiate(particlesPrefab, null);
        newParticles.transform.position = worldPosition;
        newParticles.GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(2f);
        Destroy(newParticles);
    }
}
