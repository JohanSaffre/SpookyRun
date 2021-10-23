using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public Sound.audioType type;

    // public void updateVolume(Sound.audioType type, float newVolume)
    // {
    //     FindObjectOfType<AudioManager>().changeVolume(type, newVolume);
    // }

    public void updateVolume(float newVolume)
    {
        FindObjectOfType<AudioManager>().changeVolume(type, slider.value);
    }

    // void Update()
    // {
    //     updateVolume(Sound.audioType.Music, sliderMusicVolume.value);
    //     updateVolume(Sound.audioType.Sound, sliderSoundVolume.value);
    // }
}
