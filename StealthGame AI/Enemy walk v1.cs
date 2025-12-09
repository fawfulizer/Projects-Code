using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywalkv1 : MonoBehaviour
{
    #region Positions
    [SerializeField,Tooltip("The start position to move back to")]
    Vector2 startpos;
    [SerializeField, Tooltip("A random pos to move to")]
    Vector2 RandomPos;
    [SerializeField, Tooltip("The max random to move to")]
    Vector2 MaxRandom;
    [SerializeField, Tooltip("The min random to move to")]
    Vector2 MinRandom;
    #endregion

    #region Movement
    [SerializeField, Tooltip("THe speed to walk normally at")]
    float MoveSpeed;
    [SerializeField, Tooltip("How long till resetting the position (used only with random movement and avoids getting stuck)")]
    float ResetTimer;
    //inscript timer
    float rresetTImer;
    [SerializeField, Tooltip("The min random to move to")]
    bool RandomPosition = true;

    #endregion

    EnemyStatesv1 stateScript;
    [SerializeField]
    GameObject Goto;
    //enemy state
    EnemyState state;
    //Wall script
    [SerializeField]
    WallVision wallScript;

    // Start is called before the first frame update
    void Start()
    {
        //sets start pos
        startpos = transform.position;
        //set state script
        stateScript = GetComponent<EnemyStatesv1>();
        //set itself
        //stateScript.walkScript = this;
        //the object to go to
        Goto.GetComponent<GoToCollisions>().EnemyScript = this;
        //wall script
        wallScript = GetComponentInChildren<WallVision>();
        RandomizePos();
    }

    // Update is called once per frame
    void Update()
    {
        state = stateScript.state;

        //random position
        if (RandomPosition && stateScript!=null && state== EnemyState.Walking)
        {
            MoveNormal();
        }

        //if inside of wall
        if (state == EnemyState.InsideWall)
        {
            ResetPlayerPos();

        }

    }

#region resets
    public void ResetPos()
    {
        //reset timer so that when going to an impossible position it will instead reset after X amount

        rresetTImer += Time.deltaTime;
        if (rresetTImer >= ResetTimer)
        {
            RandomizePos();
            rresetTImer -= ResetTimer;

        }
    }

    public void RandomizePos()
    {
        //randomizes x and y pos to go to
        RandomPos.x = UnityEngine.Random.Range(MinRandom.x, MaxRandom.x);
        RandomPos.y = UnityEngine.Random.Range(MinRandom.y, MaxRandom.y);
        Goto.transform.position = RandomPos;

        //script
        if (wallScript != null) { wallScript.Istouchingwall = false; }
    }

    public void MoveNormal()
    {
        //if not at position
        if (transform.position != new Vector3(RandomPos.x, transform.position.y, RandomPos.y))
        {
            //move towards the position
            transform.position = Vector3.MoveTowards(transform.position, Goto.transform.position, MoveSpeed * Time.deltaTime);
            ResetPos();

        }
        //if at position
        else
        {
            rresetTImer = 0;

        }

    }

    public void ResetPlayerPos()
    {
        //randomizes x and y pos to go to
        RandomPos.x = UnityEngine.Random.Range(MinRandom.x, MaxRandom.x);
        RandomPos.y = UnityEngine.Random.Range(MinRandom.y, MaxRandom.y);
        transform.position = RandomPos;
        state = EnemyState.Walking;
        RandomizePos();
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if at the position to go to
        if (collision.gameObject == Goto)
        {
            
            state = EnemyState.Idle;
            RandomizePos();

        }

    }
}
