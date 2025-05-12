using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NewMovingobjects : MonoBehaviour
{
    [Header("The random time bounds between new objects being created")]
    public float minRandRange;
    public float maxRandRange;
    [Header("the time the object waits to spawn (don not touch) ")]
    public float SpawnTimer;
    float timer;
   int SpawnIndex;
    [SerializeField]
    public List<GameObject> SpawnList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;   
        if(timer >= SpawnTimer)
        {
            SpawnObject();
            ResetTimer();

        }
    }

    public void SpawnObject()
    {
        //creates random object
        SpawnIndex = Random.Range(0, SpawnList.Count );
        //create object
        Instantiate(SpawnList[SpawnIndex],transform.position,transform.rotation,gameObject.transform);
    }


    public void ResetTimer()
    {
        //randomize spawn timer
        timer = 0;
        SpawnTimer = Random.Range(minRandRange, maxRandRange);
    }
}
