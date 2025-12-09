using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tooltips : MonoBehaviour
{
    bool hidden;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TextMeshProUGUI>() != null)
        {
            if (hidden)
            {
                GetComponent<TextMeshProUGUI>().text =
                    "H to show/hide tips";
            }
            else
            {
                GetComponent<TextMeshProUGUI>().text = "W/S to move\r\nA/D to turn" +
                    "\r\nTab to interact with cubes and capsules" +
                    "\r\nSpace to fire orbs" +
                    "\r\nH to show/hide tips" +
                    "\r\nR to reset enemy move destination" +
                    "\r\nBackspace to go to next level" +
                    "\r\n+ to reset level"

                    ;
            }

            if (Input.GetKeyDown(KeyCode.H)) { hidden = !hidden; }
        }
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    
}
