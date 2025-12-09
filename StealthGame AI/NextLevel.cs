using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    public string LevelToGoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(LevelToGoTo);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            if(LevelToGoTo != null && LevelToGoTo != "") { 
            SceneManager.LoadScene(LevelToGoTo);
            } else if(LevelToGoTo == "")
            {

                SceneManager.LoadScene("SampleScene");


            }


        }
    }
}
