using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetectInteractable : MonoBehaviour
{

    PlayerStateMachine movements;
    Vector3 GoTOPos;
    [SerializeField]
    GameObject GOTO;// CUZUNITYISAPIECEOFSHIT!
    // Start is called before the first frame update
    void Start()
    {
        movements = GetComponentInParent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        //Go to pos
        if(movements.DetectingHideHole || movements.DetectingSwitch)
        {
        }


        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Interactable"))
        {
            movements.DetectingInteractable = true;
            Debug.Log(other);
            movements.ResetMovement = false;

            //which interactable
            //switch
            if (other.GetComponent<DoorSwitch>()) { movements.DetectingSwitch = true; 
                GoTOPos = other.gameObject.transform.position; 
                GOTO.transform.position = GoTOPos;
                ;
            }
            //Hiding spot
            else if (other.GetComponent<HiddenObject>()) { movements.DetectingHideHole = true;
                GoTOPos = other.gameObject.transform.position; 
                GOTO.transform.position = GoTOPos;
                ;
            }
            //ORB
            else if (other.GetComponent<NextLevel>()) { movements.DetectingORB = true; 
                GoTOPos= other.gameObject.transform.position; 
                GOTO.transform.position = GoTOPos;
                ;               }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable")) { movements.DetectingInteractable = false;
            //which interactable
            //switch
            if (other.GetComponent<DoorSwitch>()) { movements.DetectingSwitch = false; }
            //Hiding spot
            else if (other.GetComponent<HiddenObject>()) { movements.DetectingHideHole = false; }
            //ORB
            else if (other.GetComponent<NextLevel>()) { movements.DetectingORB = false; }

            movements.ResetMovement = true;


        }
        GoTOPos = new Vector3(0,0,0);
    }
}
