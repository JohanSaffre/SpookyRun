using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public Sound.audioType type;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(type+"Volume");
    }

    public void updateVolume(float newVolume)
    {
        FindObjectOfType<AudioManager>().changeVolume(type, slider.value);
    }
}
