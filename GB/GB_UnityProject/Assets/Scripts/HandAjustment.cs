using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HandAjustment : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Transform bone;

    MultiAimConstraint constraint;

    bool enableDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        constraint = GetComponent<MultiAimConstraint>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(bone.position != target.position)
        {
            constraint.data.offset = new Vector3(0,90,90);
            enableDestroy = true;
        }
        else
        {
            constraint.data.offset = new Vector3(0,90,0);
            if(enableDestroy)
                Destroy(this);
        }
    }
}
