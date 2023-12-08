using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Particles : MonoBehaviour
{

    public ParticleSystem shootParticlesPrefab; // Reference to the particle system prefab
    public int poolSize = 10; // Adjust the pool size as needed

    private List<ParticleSystem> particlePool;

    void Start()
    {
        InitializeObjectPool();
    }

    void InitializeObjectPool()
    {
        particlePool = new List<ParticleSystem>();

        for (int i = 0; i < poolSize; i++)
        {
            ParticleSystem particle = Instantiate(shootParticlesPrefab, Vector3.zero, Quaternion.identity);
            particle.gameObject.SetActive(false);
            particlePool.Add(particle);
        }
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get a set of particles from the pool
            ParticleSystem particle = GetPooledParticle();

            if (particle != null)
            {
                // Get mouse position
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f; // Set the z-coordinate to 0 (they did this in the tutorial i followed IDK i dont wanna mess with this)

                // Set particle position and activate
                particle.transform.position = mousePos;
                particle.gameObject.SetActive(true);

                // Play the particle system
                particle.Play();

                // Stop the particle system after its duration
                StartCoroutine(DisableParticleAfterDuration(particle));
            }
        }
    }

    ParticleSystem GetPooledParticle()
    {
        // Find and return an inactive particle from the pool
        foreach (ParticleSystem particle in particlePool)
        {
            if (!particle.gameObject.activeSelf)
            {
                return particle;
            }
        }

        return null; // Return null if no inactive particles are found
    }

    IEnumerator DisableParticleAfterDuration(ParticleSystem particle)
    {
        // Wait for the particle system to finish playing
        yield return new WaitForSeconds(particle.main.duration);

        // Stop the particle system and deactivate the object
        particle.Stop();
        particle.gameObject.SetActive(false);
    }
}
