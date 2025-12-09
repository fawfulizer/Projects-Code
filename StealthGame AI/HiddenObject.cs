using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HiddenObject : MonoBehaviour
{
    [Header("Noise stuff")]
    [SerializeField]
    bool LoudNoise;
    [HideInInspector]
    //Checks to see if noise is needed to be made.
    public bool MakesNoise;
    [SerializeField]
    float NoiseRadius;
    public enum HideState
    {
        open,
        Hidden,
        Hearable,
        opening

    }
    public HideState HiddenState;
    [Header("BUtton stuff")]
    [SerializeField, Tooltip("How long until one can press the button again")]
    float Hidetimer;
    float hTimer;
    [Header("Sound stuff")]

    [SerializeField, Tooltip("How long the sound can be heard")]
    float SoundTImer;
    float sTimer;
    [Header("Misc")]

    [SerializeField]
    KeyCode HideKey = KeyCode.Tab;
    [SerializeField]
    GameObject Player;
    bool LockKey;

    #region AI player
    [SerializeField]
    bool AIPlayer;
    [SerializeField]

    float TImer;
    [SerializeField]

    float tt;
    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if(Player == null && !AIPlayer) { Player = GameObject.FindWithTag("Player"); }
    }

    // Update is called once per frame
    void Update()
    {
       
        #region states
        //default state
        if (HiddenState== HideState.open)
        {
            MakesNoise = false;
            sTimer  = 0;
            tt = 0;

        } else
            
        if (HiddenState == HideState.Hidden)
        {
          

            if (Player != null)
            {
                Player.SetActive(false);

            }
            MakesNoise = false;
            sTimer = hTimer = 0;
            if (Input.GetKeyDown(HideKey) && !LockKey && !AIPlayer)
            {
                Player.SetActive(true);
                HiddenState = HideState.open;
                LockKey = true;
            }

        } else
        if (HiddenState == HideState.Hearable)
        {
          
            if (Player != null)
            {
                Player.SetActive(false);

            }
            MakesNoise = true;
            if (Input.GetKeyDown(HideKey) && !LockKey&& !AIPlayer)
            {
                GetComponent<AudioSource>().Play();
                Player.SetActive(true);
                HiddenState = HideState.open;
                LockKey = true;
            }


            //AI
            if (AIPlayer)
            {
                tt += Time.deltaTime;
                if(tt >= TImer)
                {
                    OpenHide();
                    HiddenState = HideState.open;

                }


            }

        }
        else
        if (HiddenState == HideState.opening)
        {
            MakesNoise = false;
            sTimer = hTimer = 0;

        }



#endregion
        if (MakesNoise)
        {
            SoundtTime();

        }
        //  Debug.Log($"Hidden state ={HiddenState}");
        //Wait until able to exit
        if (LockKey)
        {
            Hidetime();


        }


    }
public void OpenHide()
    {
        Player.SetActive(true);
        HiddenState = HideState.open;
        LockKey = true;
        FindFirstObjectByType<PlayerStateMachine>().ResetMovement = true;
        gameObject.SetActive(false);

    }
    void SoundtTime()
    {
        sTimer += Time.deltaTime;
        if(sTimer >= SoundTImer)
        {
            MakesNoise = false;


        }

    }

    void Hidetime()
    {
        hTimer += Time.deltaTime;
        if (hTimer >= Hidetimer)
        {
            LockKey = false;
            hTimer-=Hidetimer;

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hitting Hiding");

            if (AIPlayer) {
                Player = other.gameObject;
                other.GetComponent<PlayerStateMachine>().InteractObject = gameObject;
                TImer = Random.Range(3, 13);
                HiddenState = HideState.Hearable;



            }
            else
            {
                if (Input.GetKey(HideKey) && HiddenState == HideState.open && !LockKey)
                {
                    if (LoudNoise)
                    {
                        GetComponent<AudioSource>().Play();
                        HiddenState = HideState.Hearable;
                        LockKey = true;
                    }
                    else
                    {
                        HiddenState = HideState.Hidden;

                    }


                }
            }

        }


    }

}
