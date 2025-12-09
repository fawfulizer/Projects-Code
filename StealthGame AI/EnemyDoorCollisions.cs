using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDoorCollisions : MonoBehaviour
{
    public enum DoorState
    {
        Open,
        Close


    }
    public DoorState state;
    BoxCollider col;
    MeshRenderer spriteRenderer;
    NavMeshObstacle Nav;
 
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();   
        spriteRenderer = GetComponentInChildren<MeshRenderer>();
        Nav = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == DoorState.Open)
        {
            col.enabled = false;
            spriteRenderer.enabled = false;
            Nav.enabled = false;

        }
        else if((state == DoorState.Close))
        {
            {
                col.enabled = true;
                spriteRenderer.enabled=true;
                Nav.enabled = true;
            }

        }
    }
}
