using UnityEngine;

public class SpikeRotat : MonoBehaviour
{
    EnemyMovement MoveScript;
    [SerializeField]
    bool UseMoveScript;
    [SerializeField]
    float DivisionSpeed=1;
    [SerializeField]
    float RotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveScript = GetComponent<EnemyMovement>();
        if(MoveScript == null)
        {
            MoveScript = GetComponentInChildren<EnemyMovement>();
        }
        if (MoveScript == null)
        {
            MoveScript = GetComponentInParent<EnemyMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(DivisionSpeed == 0) {DivisionSpeed = 1;}
        //walk
        if(UseMoveScript && MoveScript!= null)
        {
            if (MoveScript.Right)
            {
                Vector3 Rot = new Vector3(0, 0, -MoveScript.MoveSpeed / DivisionSpeed);

                transform.Rotate(Rot);
            }
            else
            {
                Vector3 Rot = new Vector3(0, 0, MoveScript.MoveSpeed / DivisionSpeed);

                transform.Rotate(Rot);

            }
        }
     //custom
        else  if (!UseMoveScript)
        {
            
                Vector3 Rot = new Vector3(0, 0, RotSpeed / DivisionSpeed);

                transform.Rotate(Rot);
           
        }
    }
}
