using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colllin_Game_control : MonoBehaviour
{
    [Tooltip("How many prompts to go through until the creative part starts")]
    public float MaxPrompt;

    public float CurrentPrompt;

    [SerializeField]
    GameObject Prompt;
    [SerializeField]
    GameObject EndScreen;
    bool GameEnd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPrompt >= MaxPrompt)
        {
            EndPromptGame();
         
        }

        if(Input.GetKeyDown(KeyCode.R)) { RestartGame(); }

    }

    private void EndPromptGame()
    {
        EndScreen.SetActive(true);  
        GameEnd = true;
    }

    public void CreatePrompt()
    {
        if (!GameEnd)
        {
            Instantiate(Prompt);
        }
        //throw new NotImplementedException();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Collin swipe");


    }
}
