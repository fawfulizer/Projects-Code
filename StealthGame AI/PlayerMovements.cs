using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float RotateSpeed;
    [SerializeField]
    float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Shmove = new Vector3(0, 0, Input.GetAxis("Vertical") * MoveSpeed) *Time.deltaTime;
        transform.Translate(Shmove);
        Vector3 Rotates = new Vector3(0,  Input.GetAxis("Horizontal") * RotateSpeed, 0) *Time.deltaTime;
        transform.Rotate(Rotates);
    }
}
