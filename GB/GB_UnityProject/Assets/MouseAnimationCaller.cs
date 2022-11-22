using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnimationCaller : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        anim.SetTrigger("Near");
        Debug.Log("teste");
    }
}
