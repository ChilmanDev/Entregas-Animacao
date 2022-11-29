using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    Transform followTarget;

    [SerializeField]
    bool use_offset = false;

    [SerializeField]
    bool track_rotation = false;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if(!followTarget)
            return;
        if(use_offset)
            return;

        offset = transform.position - followTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!followTarget)
            return;

        transform.position = followTarget.position + offset;

        if(track_rotation)
            transform.rotation = followTarget.rotation;
    }

    public void SetTarget(Transform target)
    {
        followTarget = target;
    }

    public void ClearTarget()
    {
        followTarget = null;
    }
}
