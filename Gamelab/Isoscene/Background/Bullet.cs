using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public
    float Movement_Speed;
    [SerializeField]
    float Rot_speed;
    //player
    GameObject Player;
    //bullet angle
    Vector3 Angle;

    public bool HomingBullet;
    public bool StartHoming;

    [SerializeField]
    bool XAxis;
    [SerializeField]
    bool YAxis;
    [SerializeField]
    bool ZAxis;


    [SerializeField]
    bool DestroyOnContact;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        if (StartHoming)
        {


            //math stuff
            float rotationes = Mathf.Atan2(Player.transform.position.y, Player.transform.position.x) * Mathf.Rad2Deg;
            //rotation
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationes - 90));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
            //makes the vector
            Vector3 Shmove = new Vector3(System.Convert.ToSingle(XAxis), System.Convert.ToSingle(YAxis), System.Convert.ToSingle(ZAxis));
        
        
        transform.Translate(Shmove * Movement_Speed * Time.deltaTime);
        if (HomingBullet)
        {


            //math stuff
            float rotationes = Mathf.Atan2(Player.transform.position.y, Player.transform.position.x) * Mathf.Rad2Deg;
            //rotation
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationes - 90));
        }
        /*
            #region agnles stuff
            float singleStep = Rot_speed * Time.deltaTime;

            //rotates and stuff
            //position of player
            Vector3 Play = Player.transform.position - transform.position;
            //actual rotation calculations
            Vector3 rotationes = Vector3.RotateTowards(transform.forward, Play, singleStep, 0.0f);
            //actual rotation
            transform.localRotation = Quaternion.LookRotation(new Vector3(rotationes.x,rotationes.y,transform.localRotation.z));
            #endregion
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DestroyOnContact)
        {
            if (collision.CompareTag("Walls"))
            {
                // Debug.Log("dhigvuighujkbk");
                Destroy(gameObject);
            }
        }
    }
}
