using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowVariation : MonoBehaviour
{
    
    float duration  = 1.0f;
    float originalRange;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        originalRange = 10.0f;
    }

    void Update()
    {
        var amplitude = Mathf.PingPong(Time.time, duration);

        // Transform from 0..duration to 0.5..1 range.
        amplitude = amplitude / duration * 0.5f + 0.5f;

        // Set light range.
        lt.range = originalRange * amplitude;
    }
    
}
