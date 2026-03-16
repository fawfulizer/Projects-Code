using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Bridges : MonoBehaviour
{

    public GameObject Segments;
    public List<GameObject> bridgePoints;

    //Is the bridge open or closed
    public bool activated;
    //Prevent repeating and making the bridge work
    public int i = 0;
    //allows the changing in states
    public bool Act;   

    //how long the changing takes
    public float ActiveTimer;
    float t;

    public LevelManager levelManager;
    //audiomanager
 public   SFXmanager Audiomanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //adds bridgepoints to list
        Transform[] Segment = Segments.GetComponentsInChildren<Transform>();
        foreach(Transform Seg in Segment)
        {
            bridgePoints.Add(Seg.gameObject);

        }
        //removes the parent (which for some reason also gets added)
        bridgePoints.RemoveAt(0);
        //start State
       
        levelManager = FindFirstObjectByType<LevelManager>();

        if (activated)
        {
            ActivatePointsStart();
            if (levelManager.ActivatedBridges < levelManager.MaxActivatedbridges)
            {
                levelManager.BridgeObjects.Add(gameObject);
        }
           
           

        }
        else
        {
            DeactivatePointsStart();


        }



    }

    // Update is called once per frame
    void Update()
    {

        if (Act)
        {

            //start scene
            if (activated)
            {
                ActivatePoints();
                

            }
            else
            {
                DeactivatePoints();


            }


            if (i >= bridgePoints.Count)

            {
                //stops the changing
                Act = false;
            }

            }
        //reset
        else
        {
                i = 0; 
        }
    }

    
    

    public void ActivatePointsStart()
    {

        if (bridgePoints.Count != 0)
        {
            //activate
            foreach (var bridgePoint in bridgePoints)
            {
                bridgePoint.SetActive(true);
            }
        }

    }

    public void DeactivatePointsStart()
    {

        if (bridgePoints.Count != 0)
        {
            //deactivate
            foreach (var bridgePoint in bridgePoints)
            {
            
                    bridgePoint.SetActive(false);
                    t = 0;

                
            }
        }

    }

    public void ActivatePoints()
    {
      
        if (bridgePoints.Count != 0)
        {

            //activate
           

            if (i< bridgePoints.Count)

            {
                //timer
                if (t < ActiveTimer)
                {
                    t += Time.deltaTime;

                }
                else
                {
                    bridgePoints[i].SetActive(true);
                    Audiomanager.PlayClipAudio(0);

                    i++;
                     t = 0;
                }
             
            }
           
        }

    }

    public void DeactivatePoints()
    {

        if (bridgePoints.Count != 0)
        {
            //deactivate
           
            if (i < bridgePoints.Count)

            {   //timer
                if (t < ActiveTimer)
                {
                    t += Time.deltaTime;

                }
                else
                {
                    bridgePoints[i].SetActive(false);
                    Audiomanager.PlayClipAudio(0);

                    i++;
                    t = 0;
                }
            }
        }

    }
    public void ToggleActive(bool act)
    {
        if (!Act)
        {
            //switch state

            // activated = !activated;
            //manager
            if (activated)
            {
                levelManager.BridgeObjects.Remove(gameObject);

                activated = false;
            }
            else
        {
            if (levelManager.ActivatedBridges < levelManager.MaxActivatedbridges)
            {
                levelManager.BridgeObjects.Add(gameObject);
               
                activated = true;
                     }

            }



            //prevents additional switches
            Act = true;
    }

    }




}

