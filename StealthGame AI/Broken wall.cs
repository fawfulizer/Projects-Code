using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Brokenwall : MonoBehaviour
{
    [Tooltip("Current broken state")]
    public int DamageState;

    //when broken
    [Tooltip("How much damage until it's broken")]
    public int MaxDamageState;
    //how much till broken
    // public int DamageToAdd;
    //is dangerous
    [Tooltip("Has it become dangerous to walk over")]
    public bool isDangerous;
    //is wal
    [Tooltip("Is it broken")]
    public bool isWall;
    [SerializeField]
    BoxCollider coll;

    NavMeshObstacle navmesh;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshObstacle>();

/*
        BoxCollider[] boxes = GetComponents<BoxCollider>();
     //find each boxcollider
        foreach (BoxCollider b in boxes)
        {
            if (!b.isTrigger)
            {
                coll = b;
                break;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Dmg = {DamageState}, mag Dmg = {MaxDamageState}");
        if (DamageState >= MaxDamageState * 0.8f && DamageState < MaxDamageState)
        {

            isDangerous = true;

        }
        else if (DamageState >= MaxDamageState)
        {
            isWall = true;
            if(GetComponentInChildren<MeshRenderer>()!=null)
            {   GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        coll.enabled = true;
            navmesh.enabled = true;
        }
    }
    public void addDamage(int DamageToAdd)
    {
        DamageState += DamageToAdd;
        //Debug.Log($"Added {DamageToAdd} to state, which is now: {DamageState}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            addDamage(other.GetComponent<EnemyStatesv1>().WeightToAdd);

          //  Debug.Log($"Hit by enemy");


        } else if (other.gameObject.CompareTag("Player"))
        {
            addDamage(1);

        }
    }
 /*   private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            addDamage(other.gameObject.GetComponent<EnemyStatesv1>().WeightToAdd);

            Debug.Log($"Hit by enemy");


        }
    }*/
}
