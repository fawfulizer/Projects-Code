using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVision : MonoBehaviour
{
    public bool Istouchingwall;

    EnemyStatesv1 StateScript;
    // Start is called before the first frame update
    void Start()
    {
      StateScript = GetComponentInParent<EnemyStatesv1>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Istouchingwall && collision.CompareTag("Wall"))
        {
            TouchingWall();
            

        }
    }

    private void TouchingWall()
    {
        StateScript.state = EnemyState.HittingWall;
        //Debug.Log($" {StateScript.state}");
        Istouchingwall = true;
        //sets the state
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!Istouchingwall && collision.gameObject.CompareTag("Wall"))
        {
            TouchingWall();


        }
    }
}
