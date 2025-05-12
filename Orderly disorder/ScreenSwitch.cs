using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitch : MonoBehaviour
{

    public GameObject StartScreen;
    public GameObject EndScreenScreen;
    public GameObject ScanScreen;

    //timer because unity sucks
    bool islocked = true;
    float maxtimer = 1;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

        // EndScreenScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (islocked)
        {
            timer += Time.deltaTime;
            if (timer >= maxtimer)
            {
                ScanScreen.SetActive(false);
                islocked = false;
            }

        }
    }

    public void StartTheGame()
    {
        if (!islocked)
        {
            StartScreen.SetActive(false);
            ScanScreen.SetActive(true);
        }

    }

    public void StartEndgame()
    {
        if (islocked)
        {
            StartScreen.SetActive(false);
            ScanScreen.SetActive(false);
        }
    }
}
