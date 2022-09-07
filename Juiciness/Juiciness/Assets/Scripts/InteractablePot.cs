using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePot : Interactable
{
    [SerializeField]
    private GameObject[] idleParticles;

    [SerializeField]
    private GameObject[] animationParticles;


    private void Start() {
        stop();
    }

    void Update()
    {
         if(animationParticles[0].activeInHierarchy)
        {
            if(animationParticles[0].GetComponent<ParticleSystem>().isStopped)
            {
                stop();
            }
        }
    }

    public override void play()
    {
        foreach (GameObject idleParticle in idleParticles)
        {
            idleParticle.SetActive(false);
        }

        foreach (GameObject animationParticle in animationParticles)
        {
            animationParticle.SetActive(true);
        }

        isPlaying = true;
    }

    protected override void stop()
    {
        foreach (GameObject idleParticle in idleParticles)
        {
            idleParticle.SetActive(true);
        }

        foreach (GameObject animationParticle in animationParticles)
        {
            animationParticle.SetActive(false);
        }

        isPlaying = false;
    }
}
