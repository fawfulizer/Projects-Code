using UnityEngine;

public class OptionsTest : MonoBehaviour
{
    public float SFXLevel;
    public float MusicLevel;
    PauseMenu Pause;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveValues(float SfX, float Music )
    {
        SFXLevel = SfX;
        MusicLevel = Music;

    }

    public void LoadValues(PauseMenu LoadFile)
    {
        
        LoadFile.SFX.value = SFXLevel;
        LoadFile.Music.value = MusicLevel;
    }



}
