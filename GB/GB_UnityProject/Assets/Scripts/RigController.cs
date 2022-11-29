using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Animations;

enum AnimationLayer{LookAt, GrabItem, LFC, LF, RFC, RF, LHC, LH, LeanLeftHand }

public class RigController : MonoBehaviour
{
    RigBuilder rb;

    public bool[] animationsControl;

    [SerializeField]
    FollowTarget observeTarget;

    [SerializeField]
    FollowTarget grabTarget;

    [SerializeField]
    FollowTarget leanOnTarget;

    public Transform test;

    Animator animator;

    [Range (0,1)]
    public float DistanceToGround;

    public LayerMask layerMask;

    
    public bool walk = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigBuilder>();
        animator = GetComponent<Animator>();
        // SetOberveTarget(test);
        // SetGrabItem(test);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < animationsControl.Length; i++)
        {
            rb.layers[i].active = animationsControl[i];
        }

        animator.SetBool("BWalk", walk);

        if(walk)
        {
            transform.position -= Vector3.forward * 3.75f * Time.deltaTime;
        }
        //if(animationsControl[(int)AnimationLayer.Steps])
        {
            //FeetIK();
        }
        
    }


    public void TriggerGrabEvent(Transform t)
    {
        SetGrabItem(t);
        animator.SetTrigger("TGrabFromFloor");
    }
    public void SetGrabItem(Transform t)
    {
        grabTarget.SetTarget(t);
    }

    public void SetOberveTarget(Transform target)
    {
        StartCoroutine(DelayedLook(1.25f));
        observeTarget.SetTarget(target);
    }

    public void StopObserveTarget()
    {
        animationsControl[(int)AnimationLayer.LookAt] = false;
        StartCoroutine(DelayedSetWalk(0.75f, true));
    }

    public void SetWalk(bool b)
    {
        walk = b;
        animator.SetBool("BWalk", b);
    }

    void StartWalk()
    {
        SetWalk(true);
    }

    public void SetAsChild(Transform t)
    {
        t.parent = transform;
    }

    IEnumerator DelayedLook(float sec)
    {
        yield return new WaitForSeconds(sec);

        animationsControl[(int)AnimationLayer.LookAt] = true;
    }

    IEnumerator DelayedSetWalk(float sec, bool b)
    {
        yield return new WaitForSeconds(sec);

        SetWalk(b);
    }

    public void SetLeanLeftHand(bool b, Transform target = null)
    {
        if(b)
        {
            leanOnTarget.SetTarget(target);
            animationsControl[(int)AnimationLayer.LeanLeftHand] = true;

        }
        else
        {
            animationsControl[(int)AnimationLayer.LeanLeftHand] = false;
        }

    }


    // void FeetIK() {
    //     RaycastHit hit;
    //     Ray ray = new Ray( leftFoot.position+ Vector3.up, Vector3.down);
    //     if(Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
    //     {
    //         Debug.Log(hit.transform.position);
    //         if(hit.transform.tag == "Walkable")
    //         {
    //             Vector3 footPositionL = hit.point;
    //             footPositionL.y += DistanceToGround;
    //             leftFoot.position = footPositionL;
    //         }
    //     }

    //     ray = new Ray( rightFoot.position+ Vector3.up, Vector3.down);
    //     if(Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
    //     {
    //         if(hit.transform.tag == "Walkable")
    //         {
    //             Vector3 footPositionR = hit.point;
    //             footPositionR.y += DistanceToGround;
    //             rightFoot.position = footPositionR;
    //         }
    //     }
    // }

}
