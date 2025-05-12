using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDSnap : MonoBehaviour
{
    //The SnapPos object/transform/rotation
    GameObject SnapPosObj;
    Vector3 SnapPos;
    Vector3 SnapRot;


    // Start is called before the first frame update
    void Start()
    {
        //finds the object
        SnapPosObj = GameObject.FindWithTag("ID Snap Pos");
        //finds the position of the object
        SnapPos = SnapPosObj.transform.position;
        //finds the right rotation offset
        SnapRot = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {//When colliding with scanner snap object to pos and rot
        if (other.CompareTag("Scanner"))
        {
            //set pos to transform
            transform.position = SnapPos;
            //set rot to transform
            transform.Rotate(SnapRot);
           
        }
    }
}