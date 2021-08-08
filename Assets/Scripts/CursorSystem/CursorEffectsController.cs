using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEffectsController : MonoBehaviour
{
    public static string prefabName = "M - CursorEffects";
    public GameObject particlesPrefab;


    [Header("Pooling settings")]
    public Queue<ParticleSystem> particlesPool;
    public int poolSize = 20;

    public SpriteRenderer cursorRenderer;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;


        InitializeCursor();
        InitializeParticlesPool();
    }

    public void InitializeCursor()
    {
        Cursor.visible = false;
    }

    public void InitializeParticlesPool()
    {
        particlesPool = new Queue<ParticleSystem>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newParticles = Instantiate(particlesPrefab, this.transform);
            ParticleSystem particlesComponent = newParticles.GetComponentInChildren<ParticleSystem>();
            particlesPool.Enqueue(particlesComponent);
        }
    }



    public void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            return;
        }

        if (Input.GetMouseButtonDown(0))
            MakePressEffect();
        UpdateMousePosition();
    }

    private void UpdateMousePosition()
    {
        cursorRenderer.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 0.5f));
    }

    public void MakePressEffect()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        ParticleSystem newParticles = particlesPool.Dequeue();
        newParticles.transform.position = worldPosition;
        newParticles.Play();
        particlesPool.Enqueue(newParticles);
    }
}
