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

    private void Start()
    {
        InitializeParticlesPool();
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
        if (Input.GetMouseButtonDown(0))
           MakePressEffect();
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
