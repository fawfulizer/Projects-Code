using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Turntowardsobject : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectToTurnTo;
    [SerializeField]
    float Offset;
    [SerializeField]
    float MinDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //current Rotation
        /* Vector3 Rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
         Vector3 FinalRotation = Vector3.RotateTowards(Rotation, ObjectToTurnTo.transform.position,RotateSpeed*Time.deltaTime, 10.0f);
         Quaternion.LookRotation(FinalRotation);
         Debug.DrawRay(transform.position, FinalRotation, Color.red);*/


        //Gets the direction
        Vector2 direction = ObjectToTurnTo.transform.position - transform.position;
        //gets the angle of that diraction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //if not closer then X amount
        if (Vector3.Distance(transform.position, ObjectToTurnTo.transform.position) > MinDistance)
        {
            //Rotate
            transform.rotation = Quaternion.Euler(0, 0, angle + Offset);
        }
        //Debug.Log($"{Vector3.Distance(transform.position, ObjectToTurnTo.transform.position)} ");
    }


}
