using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapHitBox : MonoBehaviour
{

   
    
    //same
    public ItemType type;

    //Which ID inside of the shelf.
    public int ItemID;

    public bool CorrectItem;
    //Prevents looping
    [HideInInspector]
    public bool CorrectLoop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when correct item is placed
        if (CorrectItem)
        {
            //and it doesn't loop
            if(!CorrectLoop)
            {
               // Debug.Log("Item placed");
                CorrectLoop = true;


            }
         

        }
        
    }
}
