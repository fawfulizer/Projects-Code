using System;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]

    GameObject Player;

    [SerializeField]
    float JumpStrenght;
    [SerializeField]
    SFXmanager SFX;
    Animator animator;

    bool Broken;

    [SerializeField]
    float BrokenTimer;
    float bTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Broken)
        {
            bTimer += Time.deltaTime;
            if(bTimer >= BrokenTimer )
            {
                animator.SetBool("Jump", false);
                Broken = false;


            }

        }
        else
        {
            bTimer = 0;

        }
    }


    private void OnTriggerStay(Collider other)
    {

        
            if (other.gameObject.CompareTag("Player") && !Broken)
            {
                Player = other.gameObject;
                if (Player.GetComponent<Rigidbody>().linearVelocity.y < 0 && !Player.GetComponent<Jump>().OnGround)
                {
                    Springing();
                }
            }
      
      
        
    }

    private void Springing()
    {
        animator.SetBool("Jump", true);

        //Player.GetComponent<Jump>().OnGround = true;
        Player.GetComponent<Jump>().Springjump(JumpStrenght);

        Broken = true;


    }

  /*  private void OnTriggerExit(Collider other)
    {
        if (Broken )
        {
            animator.SetBool("Jump", false);
            Broken = false;

        }
    }*/
}
