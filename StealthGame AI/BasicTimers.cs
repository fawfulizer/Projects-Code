using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    [SerializeField]
    bool ActivateObjects;
    [SerializeField]
    bool DestrouOther;
    [SerializeField]
    bool disableSelf;
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
            Reset();
        }


    }

    private void Execute()
    {
        //Creates an object
        if (CreateObject) { Instantiate(objectToCreate, transform.position, transform.rotation); }
        else
            if (ActivateObjects)
        {
            objectToCreate.SetActive(true);

        }
        else if (DestrouOther)
        {
            Destroy(objectToCreate);
        }
        else if (disableSelf)
        {
            gameObject.SetActive(false);

        }
        //Destroys itself
        if (DestroySelf) { Destroy(gameObject); }
        //Resets timer
    }

    private void Reset()
    {
        if (ResetTimer) { if (time >= MaxTime) { time = 0; } }

    }
}