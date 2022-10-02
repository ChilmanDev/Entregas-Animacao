using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FrequencyRange {SubBass, Bass, LowerMidRange, MidRange, UpperMidRange, Presence, Brilliance}

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;

    [HideInInspector]
    public float[] _samples = new float[512];

    [HideInInspector]
    public float[] _freqBand = new float[7];

    public int[] samplePerBand = new int[7];
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        /*
        0 - 20- 60
        1 - 61-250
        2 - 251-500
        3 - 501-2000
        4 - 2001-4000
        5 - 4001-6000
        6 - 6001-20000

        * 0 - 2   = 86hertz    - 0-86
        * 1 - 4   = 172 hertz  - 87-258
        * 2 - 8   = 344 hertz  - 259-602
        * 3 - 16  = 688 hertz  - 603-1290
        * 4 - 32  = 1376 hertz - 1291-2666
        * 5 - 64  = 2752 hertz - 2667-5418

        * 6 - 128 = 5504 hertz - 5419-10922
        * 7 - 256 = 11008hertz - 10923-21930   
        384 = 16512 hertz - 5419-21930

        0 - 2   = 86hertz     - 1-86
        1 - 4   = 172 hertz   - 87-258
        2 - 6   = 258 hertz   - 259-516  
        3 - 34  = 1462 hertz  - 517-1978 
        4 - 47  = 2021 hertz  - 1979-3999 
        5 - 47  = 2021 hertz  - 4000-6020
        6 - 372 = 15996 hertz - 6021-22016
                                22017
        */

        int sampleIndex = 0;

        for (int i = 0; i < 7; i++){
            float average = 0;
            int sampleCount = samplePerBand[i];

            for (int j = 0; j < sampleCount; j++){
                average += _samples[sampleIndex];
                sampleIndex++;
            }

            average /= sampleCount;

            _freqBand[i] = average;
        }
    }
}
