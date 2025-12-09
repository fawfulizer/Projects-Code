using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdetectenemy : MonoBehaviour
{
    PlayerStateMachine movements;
    // Start is called before the first frame update
    void Start()
    {
        movements = GetComponentInParent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) {
            movements.DetectingEnemy = true;
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) {  movements.DetectingEnemy = false;}
    }
}
