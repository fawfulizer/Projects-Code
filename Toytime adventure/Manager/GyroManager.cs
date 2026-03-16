using System;
using TMPro;
using UnityEngine;

public class GyroManager:MonoBehaviour 
{

    public bool EnableGyro;
    public Vector3 GyroRotation;
    public bool GryoGravity;
    public TextMeshProUGUI tmp;

    public float GyroMulitplier = 9.81f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            //if using gyro
            if (EnableGyro)
            {
                Input.gyro.enabled = true;
                GyroRotation = new Vector3(Input.gyro.attitude.x, Input.gyro.attitude.y, Input.gyro.attitude.z);
                tmp.text = $"Gyro \nX= {GyroRotation.x*0} \nY= {GyroRotation.y} \nZ= {GyroRotation.z*0}";
                //if using full gravity
                if (GryoGravity)
                {
                    Grav();

                }
                //solo obj gravity
                else
                {

                    SimpleGry();
                }
            }
            else
            {
                Input.gyro.enabled = false;
                UnityEngine.Physics.gravity = new Vector3(0, -9.81f, 0);


            }
        }

        else { //Create Buttons

            Debug.LogWarning("NO GYRO FOUND PLEAE ADD IT.");
            tmp.text = $"NO GYRO FOUND PLEAE ADD IT.";

        }
    }

    private void Grav()
    {
        UnityEngine.Physics.gravity = GyroRotation; 
    }

    private void SimpleGry()
    {
    
    }


    public void DebugGo(bool type)
    {
        EnableGyro = type;
        FindFirstObjectByType<LevelManager>().UseGyro = type;
        //Debug.LogError(type);
    }
}

  

