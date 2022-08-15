using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Point { Start = 0, Control1 = 1, Control2 = 2, End = 3}

[ExecuteInEditMode]
public class BezierCurve : MonoBehaviour
{
    private Vector2 min, max;
    
    [HideInInspector] 
    public Vector2[] points = new Vector2[4];

    [SerializeField] 
    public int steps = 10;

    void Update()
    {
        points[0] = min;
        points[3] = max;
        
        points[1] = transform.GetChild(0).transform.position;
        points[2] = transform.GetChild(1).transform.position;
    }

    private Vector2 gizmosPosition;
    private void OnDrawGizmos()
    {

        if(steps > 0)
        {
            for (float t = 0; t <= 1; t += 1f/steps)
            {
                gizmosPosition =    Mathf.Pow(1 - t, 3) * points[0] +
                                    3 * Mathf.Pow(1 - t, 2) * t * points[1] +
                                    3 * (1 - t) * Mathf.Pow(t, 2) * points[2] +
                                    Mathf.Pow(t, 3) * points[3];
                                    
                Gizmos.DrawSphere(gizmosPosition, 0.10f);
            }
        }

        Gizmos.DrawLine(points[0], points[1]);

        Gizmos.DrawLine(points[2], points[3]);
    }

    public Vector2 GetPositionInCurve(float time)
    {
        Vector2 position =  Mathf.Pow(1 - time, 3) * points[0] +
                            3 * Mathf.Pow(1 - time, 2) * time * points[1] +
                            3 * (1 - time) * Mathf.Pow(time, 2) * points[2] +
                            Mathf.Pow(time, 3) * points[3];

        return position;
    }
}
