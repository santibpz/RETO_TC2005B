// script for creating game objects (resources) at particles position 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEmitter : MonoBehaviour
{
    // game object (resource) that will be created
    [SerializeField] GameObject collectableResource;

    // particle system
    private ParticleSystem particleSystem;

    //
    List<ParticleSystem.Particle> exitParticles = new();

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to get position of particles where we want to create the resource game object
    private void OnParticleTrigger()
    {
        particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exitParticles);

        foreach (ParticleSystem.Particle particle in exitParticles)
        {
            GameObject spawnedObject = Instantiate(collectableResource);
            spawnedObject.transform.position = particle.position;
        }
    }
}
