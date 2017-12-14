using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public  static AudioManager instance;
    public bool background;
    public bool sfx;

    public sound[] sounds;


    private void Awake()
    {   
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        if( s == null)
        {
            Debug.LogWarning("silly mistake");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();

    }
    public void Pause(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    public void PlayButton(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void ResumeAudio(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
