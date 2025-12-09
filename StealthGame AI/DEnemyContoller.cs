using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class DEnemyContoller : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;

    public NavMeshAgent agent;

    public bool useMouse;

    public GameObject Goto;


    [Tooltip("What position to move to.")]
    public Transform GoToPos;

    bool Testbool;

    // Update is called once per frame
    void Update()
    {
        if (useMouse)
        {
            MouseRay();
        }
        else
        {
            // PosRay();
            if (agent.enabled == true)
            {
                agent.SetDestination(Goto.transform.position);
            }
        }        
    }

    private void PosRay()
    {
        //gets the direction between the two objects
        var GoToDirec = GoToPos.position- transform.position;
        
        //gets the mouse position to in game point
        Ray ray = new Ray(transform.position, GoToDirec);
        Debug.DrawLine(ray.origin, ray.direction,Color.red);
        //the raycas thitting?
        RaycastHit hit;
        //fires raycast (raycast, Raycasthit)
        //if it hit
        if (Physics.Raycast(ray, out hit))
        {
            //got to hitpoint
            if (agent.enabled == true)
            {
                agent.SetDestination(hit.point);
            }
            // Debug.Log($"Destination point = {hit.point}");
        }

    }

    public void Sendoutray(){
    
    
    
    }

    public void MouseRay()
    {
       
        //when mouse clicked left
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.W))
        {
            //gets the mouse position to in game point
            Ray ray= cam.ScreenPointToRay( Input.mousePosition );
            //the raycas thitting?
            RaycastHit hit;
            //fires raycast (raycast, Raycasthit)
            //if it hit
            if(Physics.Raycast(ray, out hit))
            {
                //got to hitpoint
                agent.SetDestination( hit.point );
               // Debug.Log($"Destination point = {hit.point}");
            }

        }
    }
}
