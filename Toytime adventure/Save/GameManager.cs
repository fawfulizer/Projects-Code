using System.Collections.Generic;
using System;
using UnityEngine;


public class GameManager
{
    //saving part
    GameSaveData Data;


    //level unlocked states
    public int[] LevelState = new int[25];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSavevalues(bool SaveStuff) {


        //update the save state
     Data.unlockedLevels = LevelState;
        if (SaveStuff) { Saving(); }
    }

    private void Saving()
    {

        //save
       SavingSystem.Save(LevelState);
       
        
      

    }


    void load()
    {
        //load
        Data = SavingSystem.Load<GameSaveData>();

        LevelState = Data.unlockedLevels;
    }

    //Save system

    [Serializable]
    public class GameSaveData
    {

        public int[] unlockedLevels;
        //public List<string> inventory;
        public float SFXLevel;
        public float MusicLevel;
        // Unity JsonUtility DOES NOT support Dictionary directly
        // So we wrap it using SerializableDictionary
        //public SerializableDictionary<string, int> resources = new();
    }

}
