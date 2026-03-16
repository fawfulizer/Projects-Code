using UnityEngine;

public class AudioSettings : MonoBehaviour
{


    public enum WhichLevel
    {
        SFX,
        Music


    }
    public WhichLevel Volume;

    PauseMenu pause =>FindFirstObjectByType<PauseMenu>();
    [HideInInspector]
    public float Sfxlevel;
    AudioSource audioSource => GetComponent<AudioSource>();
    public
    bool UseDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sfxlevel = pause.SFXLevel;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Volume == WhichLevel.SFX) {

            if (!UseDistance)
            {
                audioSource.volume = pause.SFXLevel;
            }
            else {
                GetComponent<DistanceVolume>().UseDistance = false;

                Debug.LogWarning("GOT AUDIO!"); }


        }
        else
        {
            if (Volume == WhichLevel.Music)
            {
                audioSource.volume = pause.MusicLevel;



            }

        }
    }


   


}
