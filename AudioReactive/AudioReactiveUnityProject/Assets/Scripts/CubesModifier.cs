using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesModifier : MonoBehaviour
{
    Transform[] audioBandObjs;
    AudioPeer _audioPeer;

    public float scaleMultplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _audioPeer  = GetComponent<AudioPeer>();

        audioBandObjs = new Transform[transform.childCount];
        for (int i = 0; i < audioBandObjs.Length; i++)
        {
            audioBandObjs[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioBandObjs.Length; i++)
        {
            audioBandObjs[i].localScale = new Vector3(audioBandObjs[i].localScale.x, _audioPeer._freqBand[i] * scaleMultplier ,audioBandObjs[i].localScale.z);
        }
    }
}
