using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCrystal : Interactable
{
    [SerializeField]
    Animator[] anim;

    [SerializeField]
    GameObject particle;
    
    private void Start() {
        stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(particle.GetComponent<ParticleSystem>().isStopped)
        {
            stop();
        }
    }

    public override void play()
    {
        foreach(Animator a in anim)
        {
            a.SetTrigger("PlayAnimation");
        }

        particle.SetActive(true);

        isPlaying = true;
    }

    protected override void stop()
    {
        particle.SetActive(false);

        isPlaying = false;
    }
}
