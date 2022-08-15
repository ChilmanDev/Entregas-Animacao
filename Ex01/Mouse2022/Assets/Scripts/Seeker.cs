using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private GameObject curvePrefab;
    private BezierCurve curve;
    private float tParam;

    [SerializeField]
    private float timeToTargetInSec;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        curve = curvePrefab.GetComponent<BezierCurve>();
        tParam = 0f;
        startPos = transform.position;

        
        StartCoroutine(GoToTargetInBezierPace());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator GoToTargetInBezierPace()
    {
        while(tParam <= 1)
        {
            Vector2 positionInCurve = curve.GetPositionInCurve(tParam);
            
            float percentage = positionInCurve.y / curve.points[(int)Point.End].y;

            Vector3 newPosition = transform.position;
            newPosition.x = startPos.x + percentage * (target.position.x - startPos.x);            

            transform.position = newPosition;

            tParam+= 1f/curve.steps;
            
            yield return new WaitForSeconds(timeToTargetInSec/curve.steps);
        }
    }

}
