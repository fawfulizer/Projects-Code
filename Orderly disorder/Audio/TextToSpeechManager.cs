using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeechManager : MonoBehaviour
{
    //THe list of sounds to play
    public List<AudioClip> Sounds;
    //The Source itself
    public AudioSource ManagerAudioSource;
    //The Current sound to play
    public int ClipIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region debug
        /* if(Input.GetKeyDown(KeyCode.Alpha0))
         {
             //sets which sound to use
             ClipIndex = 0; 
             //Fires the playsound
             PlaySound();

         }
         if (Input.GetKeyDown(KeyCode.Alpha1))
         {
             //sets which sound to use
             ClipIndex = 1;
             //Fires the playsound
             PlaySound();

         }
        */

        #endregion
    }

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
