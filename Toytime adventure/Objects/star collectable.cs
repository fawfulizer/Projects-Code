using System;
using Unity.VisualScripting;
using UnityEngine;
 
using UnityEngine.UIElements;

public class starcollectable : MonoBehaviour
{
    //The ID of the Collectable
    public int ID;
    LevelManager levelManager;
    PauseMenu pauseMenu;
    //is the star collected or not
    public bool Collected;

    SFXmanager SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //get all audio types
        SFXmanager[] s = UnityEngine.Object.FindObjectsByType<SFXmanager>(
            FindObjectsSortMode.None
        ); 

        //Check which one is the right channel
      foreach(SFXmanager F in s)
        {
            if(F.MusicType == SFXmanager.SoundType.Sfx1)
            {
                SFX = F;
               // Debug.Log("Found the sfx");

            }

        }
            
        

        levelManager = FindFirstObjectByType<LevelManager>();
        if (levelManager != null)
        {
            //adds the level and world number e.x 1 and 1 = 11;
            //ID = int.Parse(levelManager.CurrentLevel.ToString()+ levelManager.CurrentWorld.ToString());
            //ID levels
            //ID = LevelID + ((levelManager.CurrentLevel + levelManager.CurrentWorld)-2);


        }
        pauseMenu = FindFirstObjectByType<PauseMenu>();


    }

    // Update is called once per frame
    void Update()
    {
        //if star is collected
        if (pauseMenu.Collected[ID])
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(SFX != null) { SFX.PlayClipAudio(2); }
            Collected = true;
            pauseMenu.Collected[ID] = Collected;
            Destroy(gameObject);
        }
    }
}
