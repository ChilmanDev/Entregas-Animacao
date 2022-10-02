using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubesModifier : MonoBehaviour
{
    Transform[] audioBandObjs;
    AudioPeer _audioPeer;

    public float scaleMultplier = 1f;

    float[] max = new float[7]{0f,0f,0f,0f,0f,0f,0f};
    float[] count = new float[7]{0f,0f,0f,0f,0f,0f,0f};
    float[] sum = new float[7]{0f,0f,0f,0f,0f,0f,0f};
    float[] avr = new float[7];

    [SerializeField]
    GameObject debugHolder;

    [SerializeField]
    bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {
        _audioPeer  = GetComponent<AudioPeer>();

        audioBandObjs = new Transform[7];
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
            audioBandObjs[i].localScale = new Vector3(audioBandObjs[i].localScale.x, _audioPeer.getBand(i, useBuffer) * scaleMultplier ,audioBandObjs[i].localScale.z);

            if (_audioPeer.getBand(i, useBuffer) > max[i])
                max[i] = _audioPeer.getBand(i, useBuffer);

            //audioBandObjs[i].GetChild(0).GetComponent<Text>().text = max[i].ToString();
            debugHolder.transform.GetChild(0).transform.GetChild(i).GetComponent<Text>().text = ((float)System.Math.Round(max[i], 5)).ToString();

            count[i]++;
            sum[i]+= _audioPeer.getBand(i, useBuffer);

            avr[i] = sum[i] / count[i];

            debugHolder.transform.GetChild(1).transform.GetChild(i).GetComponent<Text>().text = ((float)System.Math.Round(avr[i], 5)).ToString();

        }
    }
}
