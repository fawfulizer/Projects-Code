using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXPreset : MonoBehaviour
{

    //Copy any of this code into your script to play sfx for Text to speech
    //Drag and drop the Manager object into the file (Manager is called: Text To Speech Manager)
    [SerializeField, Tooltip("The Text to speech manager which holds the script")]
    GameObject TTSManager;
    [Tooltip("The Text to speech script which is Used to play the sfx")]
    TextToSpeechManager TTSscript;

    // Start is called before the first frame update
    void Start()
    {
        //gets the script and object
        TTSscript = TTSManager.GetComponent<TextToSpeechManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Replace 0 with whatever SFX you need to play.
        TTSscript.ClipIndex = 0;
        //Plays the sound.
        TTSscript.PlaySound();
    }
}
