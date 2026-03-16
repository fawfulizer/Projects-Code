using NUnit.Framework;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndScreen : MonoBehaviour
{
    
    public List<GameObject> Stars;
    public float StarTimer;
    float sTimer;

    [SerializeField]
    Sprite StarSprite;

    public int I;

    public GameObject StarEffect;
    public bool create;


    [SerializeField]
    AudioSource music;
    [SerializeField]
    AudioSource SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        updateStars();

    }
    void updateStars()
    {
        music.Stop();


        var man = FindFirstObjectByType<PauseMenu>();


        if (man.Collected[I] && I < Stars.Count)
        {
            //create effect
            if (!create && I < Stars.Count)
            {
                //Debug.LogWarning("CreateSprite");
                GameObject Starspr = Instantiate(StarEffect, Stars[I].transform.position, Quaternion.identity, Stars[I].transform);
                create = true;
            }
            //actul create
            sTimer += Time.deltaTime;
            if (sTimer >= StarTimer && I < Stars.Count)
            {
                Stars[I].GetComponent<Image>().sprite = StarSprite;
                I++;
                create = false;
                //Debug.LogWarning("DONE CreateSprite");
                sTimer = 0;
                // continue;

            }

        }
        else
        {
            create = false;
            if (I < Stars.Count)
            {        I++;
        }
            

        }
        //Debug.LogWarning("Reachimng level end");

       

    }
    void updateStarsOld() {
        //Debug.LogWarning("Reachimng level end");

        if (!create && I < Stars.Count)
        {
            Debug.LogWarning("CreateSprite");
          GameObject Starspr  = Instantiate(StarEffect, Stars[I].transform.position, Quaternion.identity, Stars[I].transform);
                create = true;
        }
            sTimer += Time.deltaTime;
            if(sTimer>=StarTimer && I < Stars.Count) {
                Stars[I].GetComponent<Image>().sprite = StarSprite;
                I++;
            create = false;
            Debug.LogWarning("DONE CreateSprite");
            sTimer = 0;
               // continue;
           
             }
    
    }
}
