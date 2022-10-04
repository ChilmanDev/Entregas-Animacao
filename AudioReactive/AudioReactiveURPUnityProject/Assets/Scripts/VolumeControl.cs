using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    Slider _slider;
    
    [SerializeField]
    AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        float value;
        mixer.GetFloat("MasterVolume", out value);
        _slider.value = value;
    }

    // Update is called once per frame
    public void UpdateVolume()
    {
        mixer.SetFloat("MasterVolume", _slider.value);
    }
}
