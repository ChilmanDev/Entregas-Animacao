using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [HideInInspector]
    public bool trigger = false;

    [SerializeField]
    string tagFilter;

    public Transform target;

    private void Update() {

    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag != tagFilter)
            return;
        trigger = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag != tagFilter)
            return;
        trigger = false;
    }
}
