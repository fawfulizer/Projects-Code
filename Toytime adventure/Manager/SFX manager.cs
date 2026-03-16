using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public enum SoundType
    {
        Music,
        Sfx1,
        Sfx2,
        Ambience

    }
    public SoundType MusicType;

    public List<AudioClip> AudioClipList;

    public AudioSource Audiosource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClipAudio(int index)
    {
        Audiosource.clip = AudioClipList[index];
        Audiosource.Play();


    }


}
