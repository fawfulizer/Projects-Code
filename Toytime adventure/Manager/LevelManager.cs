using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region bridges
    [Header("Bridges")]
    public int ActivatedBridges;
    public int MaxActivatedbridges;
    public List <GameObject> BridgeObjects;
    #endregion
    #region Gyro
    [Header("Gyro")]
    [Tooltip("Use Gyro for specific objects")]
    public bool UseGyro;
    [Tooltip("Use Gyro for all objects")]
    public bool FullGyro;
    #endregion
    public int CurrentLevel;
    public int CurrentWorld;
    #region Level end
    [Header("Level end")]
    public int MinClearAmount =0;
    public int CurrentClearAmount;
    public int PlayerCount;
    #endregion

    #region Template
    [Header("Temp")]
    int t;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Solo obj gravity
        SetGyro(UseGyro);
        //FUll gravity
        SetFullGyro(UseGyro);

    }

    // Update is called once per frame
    void Update()
    {
        BridgeCheck();
        
    }

    private void SetGyro(bool setting)
    {
        FindFirstObjectByType<GyroManager>().EnableGyro = setting;
    }
    void SetFullGyro(bool setting)
    {
        FindFirstObjectByType<GyroManager>().EnableGyro = setting;

        FindFirstObjectByType<GyroManager>().GryoGravity = setting;


    }
    private void BridgeCheck()
    {
        ActivatedBridges = BridgeObjects.Count;
      
    }



   
}
