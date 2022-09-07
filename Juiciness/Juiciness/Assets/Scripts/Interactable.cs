using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    

    [HideInInspector]
    public bool isPlaying = false;

    public virtual void play(){}

    protected virtual void stop(){}
}
