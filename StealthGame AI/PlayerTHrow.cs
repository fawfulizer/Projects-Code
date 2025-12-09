using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerTHrow : MonoBehaviour
{
    [SerializeField]
    float ThrowSterngth;
    [SerializeField]
    float JumpStrenght;
    [SerializeField]
    GameObject Throwing;
    [SerializeField]
    KeyCode ThrowKey = KeyCode.Space;
    [SerializeField]
    float   SpawnROtateOffset;

    [SerializeField]
    Transform Parentt;

    [SerializeField]
    public bool Infinitethrow;
    [SerializeField]
    public float MaxThrow;
    public float CurrentThrow;
    [SerializeField]
    float ResetTimer;
    float Rtimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ThrowKey))
        {
            if (Infinitethrow)
            {
                CreateObject();
            }
            else
            {
                if(CurrentThrow < MaxThrow)
                {
                    CreateObject();
                    CurrentThrow++;


                }

            }


           
        }

        if (CurrentThrow >= MaxThrow)
        {
            Rtimer += Time.deltaTime;
            if (Rtimer >= ResetTimer)
            {
                CurrentThrow = 0;
                Rtimer = 0;
            }


        }

    }

   public void CreateObject() { 
    GameObject Thrown =Instantiate(Throwing,transform.position,transform.rotation);

        var OgRotation = Parentt.transform.rotation;
        //obj rotation
        Thrown.transform.rotation = Parentt.transform.rotation;
        //Thrown.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpStrenght, ThrowSterngth),ForceMode.Impulse);
        Thrown.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, JumpStrenght, ThrowSterngth), ForceMode.Force);
    }
}
