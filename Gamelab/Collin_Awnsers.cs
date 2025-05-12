using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Collin_Awnsers : MonoBehaviour
{
    //It's state
    public enum State
    {
        Init,
        Left,
        Right,


    };
    public State state;
    public bool activate;
    //immage
    public Image CurrentPrompt;
    //data saving(non server)
    #region store data
    Collin_Prompt_store StoreScript;

    #endregion
    //game controller
    Colllin_Game_control GameController;
    //get prompt data
    #region Get data
    [SerializeField]
    SpriteRenderer ImageData;
    Collin_Options Promptlist;
    int ImageID;
    #endregion

    //No double swiping fix
    bool HasSwiped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //the script to store the choice in
        StoreScript = GameObject.FindWithTag("GameController").GetComponent<Collin_Prompt_store>();
        //the game controller
        GameController = GameObject.FindWithTag("GameController").GetComponent<Colllin_Game_control>();
        //the list of prompts
        Promptlist = GameObject.FindWithTag("GameController").GetComponent<Collin_Options>();

        GetImage();
    }

   
    // Update is called once per frame
    void Update()
    {
        if (state != State.Init)
        {
            SaveAwnser();
            UpdateAwnser();
        }
    }


    private void GetImage()
    {
        //Get the script
      
        //sets to a random prompt from the list
        ImageID = Random.Range(0, Promptlist.PromptOptions.Count - 1); 
        //set the image
        ImageData.sprite = Promptlist.PromptOptions[ImageID];
        //remove from list
        Promptlist.PromptOptions.RemoveAt(ImageID);
        
    }

    private void UpdateAwnser()
    {
        if (!activate)
        {
            if (StoreScript != null)
                //update current prompt
                GameController.CurrentPrompt++;
            //add one to correct awnser list
            if (state == State.Left)
            {
                    StoreScript.LikedOptions.Add(ImageData.sprite);
                activate = true;
            }
            else
            {
                    StoreScript.DislikedOptions.Add(ImageData.sprite);
                 activate = true;
            }

        }
    }

    public void SaveAwnser()
    {
        //moving the actual card
        if (state == State.Left)
        {
            transform.Translate(Vector3.left *25* Time.deltaTime);

        }
        else if((state == State.Right)){
            transform.Translate(Vector3.right * 25 * Time.deltaTime);

        }
    }

    //for swiping
    public void SetLeft()
    {
        if (!HasSwiped)
        {
            state = State.Left;
            HasSwiped = true;
        }
    }

    public void SetRight()
    {
        if (!HasSwiped)
        {
            state = State.Right;
            HasSwiped = true;
        }
    }
//destroying
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Like")|| collision.CompareTag("Dislike"))
        {
            //update values
            UpdateAwnser();
            //create new prompt
            GameController.CreatePrompt();
            //destroy self
                Destroy(gameObject);

        }
    }

}
