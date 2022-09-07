using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCage : Interactable
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
        }
    }

    public override void play()
    {
        StopAllCoroutines();
        StartCoroutine(animPlay());
    }

    IEnumerator animPlay()
    {
        anim.SetTrigger("PlayAnimation");
        isPlaying = true;

        yield return new WaitForSeconds(2);

        isPlaying = false;
    }
}
