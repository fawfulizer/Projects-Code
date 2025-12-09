using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class GoToCollisions : MonoBehaviour
{
    [SerializeField]
    public Enemywalkv1 EnemyScript;
    
    //ranomize pos
    [SerializeField]
    Vector2 MinRandom;
    [SerializeField]
    Vector2 MaxRandom;
    [SerializeField]
    GameObject Enemy;
    [SerializeField]
    EnemyStatesv1 StateScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            RandomizePos();
        }
    }

    public void RandomizePos()
    {

        Vector3 RandomPos = new Vector3(1,Enemy.transform.position.y,1);
        //randomizes x and y pos to go to
        RandomPos.x = UnityEngine.Random.Range(MinRandom.x, MaxRandom.x);
        RandomPos.z = UnityEngine.Random.Range(MinRandom.y, MaxRandom.y);
        transform.position = RandomPos;

    }

    //wall collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RandomizePos();

        }
        //reset position
        if (collision.gameObject == Enemy)
        {
            // Debug.Log("Hitting wall");
            //regular
            if (!StateScript.NoticedSound)
            {       StateScript.state = EnemyState.Idle;}
           
            else if (StateScript.NoticedSound && StateScript.state == EnemyState.Walking)   
            {//noticed sound
                StateScript.state = EnemyState.Alerted;    

            }

            //set Temppos
            StateScript.TempPos = Enemy.transform.position;
            StateScript.TempRot = Enemy.transform.eulerAngles;
            StateScript.BoneTemp = StateScript.Bones.transform.rotation;

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall"))
        {
            RandomizePos();


        }
        //reset position
        if(collision.gameObject == Enemy && StateScript!=null)
        {
            // Debug.Log("Hitting wall");
            //regular
           
            if (!StateScript.NoticedSound)
            { StateScript.state = EnemyState.Idle; }
            else if (StateScript.NoticedSound && StateScript.state == EnemyState.Walking)
            {//noticed sound
                StateScript.state = EnemyState.Alerted;

            }


            //set Temppos
            StateScript.TempPos = Enemy.transform.position;
            StateScript.TempRot = Enemy.transform.eulerAngles;
            StateScript.BoneTemp =StateScript.Bones.transform.rotation;



        }
    }
}
