using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HiddenObject;

public class DoorSwitch : MonoBehaviour
{
    public List<GameObject> Doors;


    [SerializeField]
    KeyCode HideKey = KeyCode.Tab;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    bool LockKey;

    [SerializeField]
    float LTimer;
    [SerializeField]
    float LockTimer;

    [SerializeField]
    Material OnMat;
    [SerializeField]
    Material OffMat;
    bool Colorr;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Colorr)
        {
            GetComponent<MeshRenderer>().material =OnMat;

        }
        else
        {
            GetComponent<MeshRenderer>().material = OffMat;  

        }
        if (LockKey)
        { //Locks Input
            LockKeyTimer();
        }
    }

    void LockKeyTimer()
    {
       // LockKey = true;
        LTimer += Time.deltaTime;
        if (LTimer>= LockTimer)
        {
            LockKey = false;
            LTimer -= LockTimer;

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(HideKey) && !LockKey)
            {
                
               //Changes door state

                foreach (GameObject go in Doors)
                {
                    //set activation of all door
                    var Dor = go.GetComponent<EnemyDoorCollisions>();
                    if (Dor != null)
                    {
                        if (Dor.state == EnemyDoorCollisions.DoorState.Close)
                        {        Dor.state = EnemyDoorCollisions.DoorState.Open;
                              }
                        else
                        {
                            Dor.state = EnemyDoorCollisions.DoorState.Close;

                        }
                    }
                   

                }



                //Changes color
                Colorr = !Colorr;
                

               
                    LockKey = true;
                
            
            
            }
                

            }


        }


    }


