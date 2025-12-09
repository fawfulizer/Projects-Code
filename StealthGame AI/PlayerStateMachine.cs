using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateMachine : MonoBehaviour
{
    #region basic scripts

    public enum PlayerState
    {
        Null,
        Idle,
        Walking

    }

    public PlayerState state;

    [Tooltip("How long it wait while idling before returning back to moving")]
    public float IdleWaitTime;



    [Tooltip("How long it wait until resetting")]
    public float Nothittingtimer;
    public bool ResetMovement;

    public Vector3 TempPos;
    public Vector3 TempRot;

    public float IdleTimer;
    float ITimer;

    #endregion
    #region scripts
    [HideInInspector]
    public NavMeshAgent walkScript;
    [SerializeField]
    public GoToCollisions Goto;

    [SerializeField]
    float ResetTimer;
    float RReset;

    #endregion


    #region sound stuff
    public bool NoticedSound;

    //turn stuff
    public float TurnAmplitude;
    public float TurnSpeed;
    //BOnes
    public Quaternion BoneTemp;
    Quaternion BoneStart;
    public GameObject Bones;




    #endregion


    #region Detection stuff
    //Enemy
    public bool DetectingEnemy;
    //detect general interacting
    public bool DetectingInteractable;
    //public string WhichInteractable;
    //door switches
    public bool DetectingSwitch;
    //Hiding places
    public bool DetectingHideHole;
    //levelend
    public bool DetectingORB;

    //used to interact with the other object
    public GameObject InteractObject;
    int RandomChance;

    #endregion



    public int WeightToAdd;


    //runawya
    float EnemeyTimer;
    bool En;

    // Start is called before the first frame update
    void Start()
    {
        Getscripts();
        ResetMovement = true;
        BoneStart = Bones.transform.rotation;
    }

    private void Getscripts()
    {
        checkingINteract();
        walkScript = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        StateCheck();
        checkingINteract();
        //runaway timer
        if (En) { RUN(); } else { EnemeyTimer = 0; GameObject detect = GetComponentInChildren<playerdetectenemy>().gameObject;
            detect.SetActive(true);
        }
        

    }
    #region states
    private void StateCheck()
    {


        switch (state)
        {
            //null
            case PlayerState.Null:
                RReset = 0;
                //StartCoroutine(IdleWait());
                idTimer();
                Debug.Log($"Error invalid state at {gameObject.GetInstanceID()}");
                break;

            //idle
            case PlayerState.Idle:
                RReset = 0;
                //StartCoroutine(IdleWait());
                idTimer();
                if (walkScript.enabled == false)
                {
                    Bones.transform.rotation = BoneStart;
                    walkScript.enabled = true;
                }
                break;

            //walking
            case PlayerState.Walking:
                ITimer = 0;
                NotHittingWait();
                break;

         

        }


    }

    

    void idTimer()
    {

        if (state == PlayerState.Idle || state == PlayerState.Null)
        //waits
        {
            ITimer += Time.deltaTime;
            //Reset to walking
            if (ITimer >= IdleTimer)
            {
                state = PlayerState.Walking;
                //resets the position to go to
                Goto.RandomizePos();

                //for empty enums
            }
        }



    }
    void NotHittingWait()
    {
        RReset += Time.deltaTime;
        if (RReset >= ResetTimer)
        {
            if (ResetMovement)
            {       Goto.RandomizePos();
                                }

            RReset -= ResetTimer;
        }


    }

    #endregion

    void checkingINteract()
    {
        //var hide = Convert.ToInt32(DetectingHideHole);
        //var swith = Convert.ToInt32(DetectingSwitch);
        //var ORB = Convert.ToInt32(DetectingORB);


        #region resets
        if (!DetectingEnemy && !DetectingInteractable)
        {
            RandomChance = 0;
            ResetMovement = true;

        }
        #endregion

        //hide chance
        if (DetectingHideHole && !DetectingEnemy)
        {
            //randomize
            RandomChance = UnityEngine.Random.Range(0,10);
            //Hide
            if (RandomChance < 3)
            {
                Debug.Log("Got hide");
                //  Debug.Log("Player is hiding");
                Hiding();
            }
            else
            {
                RandomChance = 0;

            }


        }
        //hide with enemy
        if (DetectingHideHole && DetectingEnemy)
        {
            //randomize
            RandomChance = UnityEngine.Random.Range(0, 10);
            //Hide
            if (RandomChance < 6)
            {
                Debug.Log(" hide");
                // Debug.Log("Player is hiding");
                Hiding();
            }
            else if (RandomChance < 7 && RandomChance > 5)
            {
                //  Debug.Log("Throw ball");
                PlayerTHrow throwscrpt = GetComponentInChildren<PlayerTHrow>();
                //  Debug.Log("Throw ball");
                if (throwscrpt.Infinitethrow && RandomChance != 99)
                {
                    throwscrpt.CreateObject();
                    throwscrpt.CurrentThrow++;
                    RandomChance = 99;

                }
                else
                {
                    if (throwscrpt.CurrentThrow < throwscrpt.MaxThrow && RandomChance != 99)
                    {
                        throwscrpt.CreateObject();
                        throwscrpt.CurrentThrow++;
                        RandomChance = 99;
                    }

                }
            }
            else
            {
                //  Debug.Log("Run away");

                if (ResetMovement)
                {
                    Goto.RandomizePos();
                    En = true;
                }
                ResetMovement = false;

                if(Goto.transform.position == transform.position)
                {

                   // Goto.RandomizePos();
                   // En = true;
                }
            }

        }

        //enemy no hide
        if (!DetectingHideHole && DetectingEnemy)
        {
            Debug.Log(" ababaab");

            //randomize
            RandomChance = UnityEngine.Random.Range(0, 10);
            //Hide
            
             if (RandomChance < 7)
            {
                Debug.Log(" Throw");

                //  Debug.Log("Throw ball");
                PlayerTHrow throwscrpt = GetComponentInChildren<PlayerTHrow>();
                if (throwscrpt.Infinitethrow && RandomChance != 99)
                {
                    throwscrpt.CreateObject();
                    throwscrpt.CurrentThrow++;
                    RandomChance = 99;

                }
                else 
                {
                    if (throwscrpt.CurrentThrow < throwscrpt.MaxThrow && RandomChance != 99)
                    {
                        throwscrpt.CreateObject();
                        throwscrpt.CurrentThrow++;
                        RandomChance = 99;
                    }

                }
            }
            else
            {
                Debug.Log("Run away");
                if (ResetMovement)
                {
                    Goto.RandomizePos();
                    En = true;
                }
                ResetMovement = false;
                if (Goto.transform.position == transform.position)
                {

                    Goto.RandomizePos();
                    En = true;
                }

            }

        }


    }


    void RUN()
    {
        if(GetComponentInChildren<playerdetectenemy>().gameObject!=null)
        {
            GameObject detect = GetComponentInChildren<playerdetectenemy>().gameObject;
            detect.SetActive(false);
            var t = 5;

            EnemeyTimer += Time.deltaTime;
            if (EnemeyTimer >= t)
            {
                En = false;

            }
        }


    }
    void Hiding()
    {
        int Rrandom = UnityEngine.Random.Range(0, 10);
        //Hide
        if (InteractObject.GetComponent<HiddenObject>() != null)
        {
            if (Rrandom < 5)
            {

                InteractObject.GetComponent<HiddenObject>().HiddenState = HiddenObject.HideState.Hearable;
                Debug.Log("Got hide");
            }
            //show
            else
            {
                InteractObject.GetComponent<HiddenObject>().HiddenState = HiddenObject.HideState.open;
                Debug.Log("Not hide");
                Goto.RandomizePos();

            }

        }

    }
}