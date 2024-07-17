using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public AudioMixerGroup audioMixer;


    void Awake()
    {

        //DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = audioMixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    //¯eby zagraæ dzwiêk to trzeba wpisaæ to: FindObjectOfType<AudioManager>().Play("nazwa_dzwiêku");


    private void Start()
    {
        Play("");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
            
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }

        s.source.Stop();
    }

}
