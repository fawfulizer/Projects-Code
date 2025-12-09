using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    //empty
    Null,
    //idleing
    Idle,
    //walking
    Walking,
    //after reaching the go to point
    Waiting,
    //After being alerted by something
    Alerted,
    //is it walking towards a wall
    HittingWall,
    //is it inside a wall
    InsideWall
}
public class EnemyStatesv1 : MonoBehaviour
{
    #region basic scripts

    public EnemyState state;

    [Tooltip("How long it wait while idling before returning back to moving")]
    public float IdleWaitTime;



    [Tooltip("How long it wait until resetting")]
    public float Nothittingtimer;


    public Vector3 TempPos;
    public Vector3 TempRot;

    public float IdleTimer;
    float ITimer;

    #endregion
    #region scripts
    [HideInInspector]
    public NavMeshAgent walkScript;
    [SerializeField]
    GoToCollisions Goto;

    [SerializeField]
    float ResetTimer;
    float RReset;

    bool timerREset;
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

    //TurnTimer
    [SerializeField]
    float TurnTimer;
    float Ttimer;


    #endregion

    public int WeightToAdd;

    // Start is called before the first frame update
    void Start()
    {
        Getscripts();
        BoneStart = Bones.transform.rotation;
    }

    private void Getscripts()
    {
      walkScript = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        StateCheck();



    }
    #region states
    private void StateCheck()
    {
     

        switch (state)
        {
            //null
            case EnemyState.Null:
                RReset = 0;
                //StartCoroutine(IdleWait());
                idTimer();
                Debug.Log($"Error invalid state at {gameObject.GetInstanceID()}");
                break;
                
                //idle
            case EnemyState.Idle:
                RReset = 0;
                //StartCoroutine(IdleWait());
                idTimer();
                if(walkScript.enabled == false)
                {
                    Bones.transform.rotation = BoneStart;
                    walkScript.enabled = true;
                }
                break;

            //walking
            case EnemyState.Walking:
                ITimer = 0;
                NotHittingWait();
                break;

            //walking
            case EnemyState.Alerted:
                TurntTIme();
                AlertTurn();
                ITimer = 0;
                break;

        }
            
                
    }

    private void TurntTIme()
    {
        Ttimer += Time.deltaTime;
        if (Ttimer >= TurnTimer)
        {
           
            state = EnemyState.Idle;
            walkScript.enabled = true;
            NoticedSound = false;
            //reset timer
            Ttimer -= TurnTimer;
        }
    }

    private void AlertTurn()
    {
        
        var Shmove = Mathf.Cos(BoneTemp.y * TurnAmplitude*Time.time) * TurnSpeed;
        var BoneShmove = Quaternion.Euler(BoneTemp.x, Shmove, BoneTemp.z);
        Bones.transform.rotation = BoneShmove;
        walkScript.enabled = false;
    }

    IEnumerator IdleWait()
    {
        if(state == EnemyState.Idle || state == EnemyState.Null)
        //waits
        {
            yield return new WaitForSeconds(IdleWaitTime);
            //Reset to walking
            state = EnemyState.Walking;
            //resets the position to go to
            Goto.RandomizePos();
            //for empty enums
        }
        else
        {
            yield return null;


        }
        yield return null;

    }

    void idTimer()
    {

        if (state == EnemyState.Idle || state == EnemyState.Null)
        //waits
        {
            ITimer += Time.deltaTime;
            //Reset to walking
            if (ITimer >= IdleTimer)
            {
                state = EnemyState.Walking;
                //resets the position to go to
                Goto.RandomizePos();
             
               //for empty enums
            }
        }
     
      

    }
    void NotHittingWait()
    {
        RReset += Time.deltaTime;
        if (RReset >=ResetTimer)
        {
            Goto.RandomizePos();

            RReset -= ResetTimer;
        }


    }

    #endregion





}
