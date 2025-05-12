using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BasicTimers : MonoBehaviour
{
    float time;
    [SerializeField]
    float MaxTime;
    #region options
    [SerializeField, Tooltip("Does it create anything when timer is hit")]
    bool CreateObject;
    [SerializeField]
    GameObject objectToCreate;

    [SerializeField, Tooltip("Does it Destroy itself when timer is hit")]
    bool DestroySelf;

    [SerializeField, Tooltip("Does the timer reset")]
    bool ResetTimer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }


    private void Timer()
    {
        time += Time.deltaTime;
        if (time >= MaxTime)
        {
            Execute();

        }


    }

    private void Execute()
    {
        //Creates an object
        if (CreateObject) { Instantiate(objectToCreate, transform.position, transform.rotation); }
        //Destroys itself
        if (DestroySelf) { Destroy(gameObject); }
        //Resets timer
        if (ResetTimer) { time = 0; }
    }
}