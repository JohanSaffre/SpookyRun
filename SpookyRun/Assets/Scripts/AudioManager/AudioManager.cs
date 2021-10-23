using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public Sound[] sounds;

    // Awake is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.loop = sound.loop;
            sound.source.Stop();
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: \"" + name +"\": not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: \"" + name +"\": not found.");
            return;
        }
        s.source.Stop();
    }

    public void changeVolume(Sound.audioType type, float newVolume)
    {
        foreach (Sound sound in sounds) {
            if (sound.type == type) {
                sound.volume = newVolume;
                sound.source.volume = sound.volume;
            }
        }
    }

    public void StopAllMusic()
    {
        foreach(Sound sound in sounds) {
            if (sound.type == Sound.audioType.Music)
                sound.source.Stop();
        }
    }
}
