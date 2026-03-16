using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
//using UnityEditor.UI;
using UnityEditor;
using TMPro;
using NUnit.Framework.Internal;

public class PauseMenu : MonoBehaviour
{
    #region main pause menu
    public enum State
    {
        UnPause,
        MainPause,
        Settings,


    }

    public State Pausestate;

    public List<Sprite> Icons;
    public Image Icon;
    [Tooltip("Objects to turn invisible when paused")]
    public List<GameObject> PauseInvisible;
    [Tooltip("Objects to turn visible when paused")]
    public List<GameObject> PauseVisible;

    public AudioSource PauseSource;
    #endregion


    #region Save stuff
    //used for the offset (+3*(LevelId=-1))
    [HideInInspector]
    public int LevelId => FindFirstObjectByType<LevelManager>().CurrentLevel;

    public List<bool> Collected = new List<bool> { false, false, false };

    #endregion

    public List<GameObject> Menus;
    int M;

    #region SFXStuff
    public Slider Music;
    public Slider SFX;

    public float MusicLevel;
    public float SFXLevel;


    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disable other objects

        foreach (GameObject p in PauseVisible)
        {
            p.SetActive(false);
            load();

        }

         


        UpdateMenus();
        foreach (GameObject p in Menus)
        {
            p.SetActive(false);

        }



    }

    // Update is called once per frame
    void Update()
    {
        //pauses time
        if (Pausestate == State.UnPause)
        {
            Time.timeScale = 1.0f;

            //unpauses
        }
        else { Time.timeScale = 0.0f; }




        //set audio values
        SFXLevel = SFX.value;
        MusicLevel = Music.value;
    }

    public void ChangeStates(int a)
    {
        switch (a)
        {
            case 1:
                Saving();
                Pausestate = State.MainPause;
                UpdateMenus();

                break;
            case 2:

                Pausestate = State.Settings;
                UpdateMenus();

                break;
            case 3:
                Saving();
                Pausestate = State.MainPause;
                UpdateMenus();
                break;


        }
    }
    public void PauseChange()
    {
        if (Pausestate == State.MainPause)
        {
            Icon.sprite = Icons[0];

            Pausestate = State.UnPause;

            //enable other objects
            foreach (GameObject p in PauseInvisible)
            {
                p.SetActive(true);

            }



            //Disable other objects

            foreach (GameObject p in PauseVisible)
            {
                p.SetActive(false);

            }





            PauseSource.enabled = false;

        }
        else if (Pausestate == State.UnPause)
        {
            Icon.sprite = Icons[1];
            Pausestate = State.MainPause;
            //Disable other objects

            foreach (GameObject p in PauseInvisible)
            {
                p.SetActive(false);

            }



            //enable other objects
            foreach (GameObject p in PauseVisible)
            {
                p.SetActive(true);

            }
            PauseSource.enabled = true;
            load();

        }
    }




    public void UpdateMenus(/*int Direc*/)
    {
        //active/deactuve menus
           int M = 0;
           foreach (GameObject p in Menus)
           {
               if ((M+1) == (int)Pausestate)
               {
                   p.SetActive(true);

               }
               else { p.SetActive(false); }
               M++;

           }
     /*   if (Direc ==-1)
        {
            foreach (GameObject p in Menus)
            {
                RectTransform Rect = p.GetComponent<RectTransform>();
                Vector2 Destination = new Vector2(Rect.anchoredPosition.x - 150, Rect.anchoredPosition.y);

                Rect.anchoredPosition = Vector2.Lerp(Rect.anchoredPosition, Destination, 500 * Time.deltaTime);

            }

           
        }*/
    }

    public void Saving()
    {
        Debug.LogWarning("SAVING");
        //save
      /*  GameSaveData Data = SavingSystem.Load<GameSaveData>();
        Data.MusicLevel = MusicLevel;
        Data.SFXLevel= SFXLevel;
        */
        //new saving test (does not save on restarts)
        var saf = FindFirstObjectByType<OptionsTest>();
        if (saf != null)
        {
            saf.SaveValues(SFXLevel, MusicLevel);

        }
        

    }


    public void load()
    {
        Debug.LogWarning("LOADING");
     /*   GameSaveData Data;
        //load
        Data = SavingSystem.Load<GameSaveData>();

        SFXLevel = Data.SFXLevel;
        MusicLevel= Data.MusicLevel;
       */
        //new saving test (does not save on restarts)
        var saf = FindFirstObjectByType<OptionsTest>();
        if (saf != null)
        {



            saf.LoadValues(this);
        }

    }

}