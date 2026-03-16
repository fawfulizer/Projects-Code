using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MoveSpeed;
    public bool Right;
    public bool Walking;
    public bool FlipDistance;
    public float FlipTimer;
    float Ftime;
    
    public bool FlipTriggers;



    public GameObject Rot;
    float StartRot;
    public Animator an;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // an =  GetComponent<Animator>();
        // if (an == null) {an = GetComponentInChildren<Animator>();}
        if (Rot != null)
        {
            StartRot = Rot.transform.rotation.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float XDirec = transform.position.x;
        if (Walking)
        {
            DoWalking();
            if (FlipDistance)
            {
                Flipping();

            }
          if(an!=null)
            an.SetFloat("State", 1);
        }
        else
        {
            if (an != null)
                an.SetFloat("State", 0);

        }



        if (Rot != null)
        {
            //direc
            if (Right)
            {
                Rot.transform.rotation = Quaternion.Euler(0, StartRot - 45, 0);
            }
            else
            {
                Rot.transform.rotation = Quaternion.Euler(0, StartRot + 45, 0);
            }
        }
    }

    private void Flipping()
    {
        Ftime += Time.deltaTime;
        if(Ftime>= FlipTimer)
        {

            Right = !Right;
            Ftime = 0;
        }
    
    
    }

    private void DoWalking()
    {
        if (Right)
        {


            Vector3 SHmove = new Vector3(MoveSpeed * Time.deltaTime, 0, 0);

            transform.Translate(SHmove);
            //transform.rotation = Quaternion.Euler(0, StartRot+  45, 0);
        }
        else
        {

            Vector3 SHmove = new Vector3(-MoveSpeed * Time.deltaTime, 0, 0);

            transform.Translate(SHmove);
            //transform.rotation = Quaternion.Euler(0, StartRot, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(FlipTriggers &&other.CompareTag("Flip"))
        {
            Flipping();

        }
    }


}
