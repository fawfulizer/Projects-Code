using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Endscreen : MonoBehaviour
{
    [SerializeField, Tooltip("Checks the amount of correct/wrong items")]
    Endresult ResultScript;

    [SerializeField, Tooltip("Checks the amount of Score the player gets")]
    //Score;
    ScoreSystem ScoreE;


    [SerializeField]
    GameObject EndScreenObject;

    [SerializeField]
    TextMeshProUGUI Score;

    [SerializeField]
    TextMeshProUGUI GoodBadAmount;

    [SerializeField, Tooltip("Vera's scanner screen")]
    GameObject VeraScreen;

    [SerializeField, Tooltip("Niko's start/pause screen")]
    GameObject NikoScreen;
    // Start is called before the first frame update
    void Start()
    {
        //subscribe to event
        ResultScript.EnableEndScreen += ShowEndScreen;
        EndScreenObject.SetActive(false);
        //niko score
        ScoreE = gameObject.GetComponent<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEndScreen()
    {
        EndScreenObject.SetActive(true);
        if(NikoScreen !=null && VeraScreen != null) {
            NikoScreen.SetActive(false);
            VeraScreen.SetActive(false);
        }
        ShowText();
       // Debug.Log("Fuck youo unity you piece of shit why do you always break last second piece of shit!");
    }

    void ShowText()
    {
        Score.text = $"Score: {ScoreE.score}";

        GoodBadAmount.text = $"Correct items placed:{ResultScript.correctAmount}\n Wrong items placed:{ResultScript.wrongAmount}";


    }

}
