using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public Vector3 gravityDirection = new Vector3(0, -1, 0); // downward
    public float gravityStrength = 9.81f;

    Rigidbody rb;

    public bool TowardsPoint;
    
    //towards a point
    [SerializeField]Transform gravityCenter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       //Gyro based
        if (FindFirstObjectByType<LevelManager>().UseGyro)
        { ChangeGyro();
            Debug.Log("USING GYRO");
        
        }
        else {
            //point based
            if (TowardsPoint)
            {
                GravToPoint();

            }
            //regular
            else
            {
                rb.AddForce(gravityDirection.normalized * gravityStrength, ForceMode.Acceleration);


            }

        }
    }
    public void GravToPoint() {
        Vector3 dir = (gravityCenter.position - transform.position).normalized;
        rb.AddForce(dir * gravityStrength, ForceMode.Acceleration);


    }

    public void ChangeGyro()
    {
        GyroManager man = FindFirstObjectByType<GyroManager>();
        Vector3 Gr = new Vector3(-man.GyroRotation.y * man.GyroMulitplier, 0,0);
        rb.AddForce(Gr.normalized * gravityStrength, ForceMode.Acceleration);
    }
    
}