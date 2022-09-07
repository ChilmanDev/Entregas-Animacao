using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFlask : Interactable
{
    Shakev2 shakevScript;
    // Start is called before the first frame update
    void Start()
    {
        shakevScript = GetComponent<Shakev2>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlaying = shakevScript.isPlaying;
    }

    public override void play()
    {
        shakevScript.Begin();
    }
}
