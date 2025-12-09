using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThrownItem : MonoBehaviour
{
    [HideInInspector]
 public   bool isOnGround;

    AudioSource source;

    //hearing

    [HideInInspector]
    public bool NoMoreSound;
    [SerializeField]
    float HearTimer = 2f;
    float Timer;


    //wait till hearable
    bool CanSPawn;
    float spawnTime=0.3f;
    float stime;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnGround && !NoMoreSound)
        {

            Hearing();

        }

        if (!CanSPawn)
        {

            stime += Time.deltaTime;
            if(stime >= spawnTime)
            {
                CanSPawn = true;

            }
        }
        {
            
        }
    }

    private void Hearing()
    {
        Timer += Time.deltaTime;
        if(Timer >= HearTimer)
        {
            NoMoreSound = true;


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CanSPawn)
        {
            isOnGround = true;
            source.Play();
        }
    }
}
