using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepathingSee : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TheRay()
    {


        //gets the mouse position to in game point
        Ray ray = new Ray(transform.position, Vector3.forward);
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        //the raycas thitting?
        RaycastHit hit;
        //fires raycast (raycast, Raycasthit)
        //if it hit
        if (Physics.Raycast(ray, out hit))
        {
            //has the broken wall script
            if (hit.collider.gameObject.GetComponent<Brokenwall>()!=null)
            {
                var scrpt = hit.collider.gameObject.GetComponent<Brokenwall>();
                if (scrpt.isDangerous)
                {
                    GetComponent<NavMeshAgent>().ResetPath();

                }

            }

        }




    }
}
