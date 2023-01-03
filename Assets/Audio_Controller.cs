using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Controller : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    AudioSource myAudio;
    float musicVolume = 0.1f;
    // Start is called before the first frame update
    void Start()

    {
        myAudio = GetComponent<AudioSource>();

        volumeSlider.value = myAudio.volume;
    }

    // Update is called once per frame
    void Update()
        
    {
        myAudio.volume = musicVolume;
    }
    public void Volume(float volume)
    {
        musicVolume = volume;

    }
}
