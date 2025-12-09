using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearSound : MonoBehaviour
{
    [SerializeField]
    GameObject GoTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //if sound object
        if (other.gameObject.CompareTag("SoundDistraction")) {

            //if not on ground
            if (other.GetComponent<ThrownItem>() != null)
            {
                if (other.GetComponent<ThrownItem>().isOnGround && !other.GetComponent<ThrownItem>().NoMoreSound)
                {
                    //set the destination to the sound
                    GoTo.transform.position = other.transform.position;
                    Destroy(other);
                    //sets the state to alerted
                    GetComponentInParent<EnemyStatesv1>().NoticedSound = true;
                    GetComponent<AudioSource>().Play();
                }
            }

            //hidden Item
            else if (other.GetComponent<HiddenNoiseCollider>() != null)
                {
                if (other.GetComponent<HiddenNoiseCollider>().Hearable)
                {
                    //Debug.Log("Reached the scriptGetting");

                    //set the destination to the sound
                    GoTo.transform.position = other.transform.position;
                    GetComponentInParent<EnemyStatesv1>().NoticedSound = true;
                   // GetComponent<AudioSource>().Play();
                }
                }
             
        }
    }
}
