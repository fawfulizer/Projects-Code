using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collin_Prompt_store : MonoBehaviour
{//awnsers
    public List<Sprite> LikedOptions;
    public List<Sprite> DislikedOptions;

    //Unique people code
    public List<string> Usercode;

    //Date of playing
    public List<string> PlayDates;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //add unique user code
       // Usercode.Add($"{Usercode.Count+1}");
        //Usercode.Add( System.Guid.NewGuid);
        //adds date and time
        PlayDates.Add($"{System.DateTime.Now}");
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
