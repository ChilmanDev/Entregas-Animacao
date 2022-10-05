using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePlay : MonoBehaviour
{
    public bool paused;
    
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    Material playImage, pauseImage;

    Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        paused = false;
    }

    public void TooglePause()
    {
        paused = !paused;

        if(paused) audioSource.Pause();
        else audioSource.Play();
    }

    void Update() {
        if(!audioSource.isPlaying)
        {
            paused = true;
        }

        _button.image.material = paused ? playImage : pauseImage;

    }
}
