using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Endresult : MonoBehaviour
{
    [Tooltip("The amount correctly placed")]
    public int correctAmount;

    [Tooltip("The amount wrongly placed")]
    public int wrongAmount;

    [Tooltip("The amount of objects to place")]
    public int fullAmount;

    [Tooltip("THe list of objects")]
    public GameObject[] items;
    //public Dictionary<GameObject, bool> ItemList;
    Snapitem snapitem;
    //event to open UI
    public event UnityAction EnableEndScreen;
    [Tooltip("Current amount of items placed")]
    public int Current_placed;


    // Start is called before the first frame update
    void Start()
    {
        //the list of gameobjects
        items = GameObject.FindGameObjectsWithTag("Item");
        //to make the amount easier
        fullAmount = items.Length;
        //event subscribe
        //snapitem.AddGood += AddGoodAmount;
        
    }

    // Update is called once per frame
    void Update()
    {
        //precautions
        if(wrongAmount < 0)
        {
            wrongAmount = 0;

        }
        if(correctAmount > fullAmount)
        {
            correctAmount = fullAmount;

        }
        
        //activate the endscreen when all is placed
        if(Current_placed >= fullAmount)
        {
            //if (fullAmount != 0)
           // {
                EndScreenActivate();
                Debug.Log("Ya did it!");
           // }
        }
        
        //debug
        //EndScreenActivate();
    }

    public void EndScreenActivate()
    {
        wrongAmount = fullAmount - correctAmount;
        EnableEndScreen.Invoke();
        Endscreen FuckUnity = GetComponent<Endscreen>();
        FuckUnity.ShowEndScreen();
        //disable script
        Endresult script = gameObject.GetComponent<Endresult>();
        script.enabled= false;


    }

    public void AddGoodAmount()
    {
        correctAmount++;
        //niko code
        ScoreSystem ScoreScript = gameObject.GetComponent<ScoreSystem>();
        ScoreScript.AddScoreForCorrectPlacement(1 );
    }
    public void SubGoodAmount()
    {
        correctAmount--;
        //niko code
        ScoreSystem ScoreScript = gameObject.GetComponent<ScoreSystem>();
        ScoreScript.AddScoreForCorrectPlacement(-1);
    }

}
