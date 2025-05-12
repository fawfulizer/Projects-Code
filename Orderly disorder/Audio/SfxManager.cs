using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    // Start is called before the first frame update
    //THe list of sounds to play
    public List<AudioClip> Sounds;
    //The Source itself
    public AudioSource ManagerAudioSource;
    //The Current sound to play
    public int ClipIndex;

  
   

    public void PlaySound()
    {
        if (ClipIndex <= Sounds.Count && ClipIndex > -1)
        {
            //Sets the actual audioclip
            ManagerAudioSource.clip = Sounds[ClipIndex];
            //Play the sound
            ManagerAudioSource.Play();
        }
        else
        {
            //When greater then max or lower then 0
            Debug.Log($"Error, Sound not found. Max index is {Sounds.Count}, Current sound is {ClipIndex}");

        }
    }
}
