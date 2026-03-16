using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool OnGround;
    public int JumpAmount = 1;
    int jmp;
    public float JumpStrength;
    [Tooltip("Used as a starting offset to push the player off of the ground")]
    public float StartDist = 3;


   public SFXmanager SFX;

//Ground detection
    Ray cast;
    // How far the ray should check

    public float checkDistance = 2f;              
    public LayerMask groundMask;

    public bool SFXManager = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jmp = JumpAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnGround)
        {
            groundCheck();
        }
        
    }


    public void groundCheck()
    {
        //creates raycasgt
         cast = new Ray(transform.position, Vector3.down);
        RaycastHit hit;


        //if raycast hits the ground
        if (Physics.Raycast(cast, out hit, checkDistance, groundMask))
        {
          //  Debug.Log($"Hit {hit.collider.name} at distance {hit.distance}");

            // Check if the hit distance is shorter than the checkDistance
            if (hit.distance < checkDistance)
            {
                if (!OnGround)
                {
                    GetComponentInChildren<PLayerMoveVertical>().PlayerMoveState = PState.idle;
                    GetComponentInChildren<NessieAnimations>().ChangeStates(NessieState.Idle);

                    if (!SFXManager && SFX!= null)
                    {
                        SFX.PlayClipAudio(1);
                    }
                    jmp = JumpAmount;
                    OnGround = true;
                }
            }
        }
        else
        {
          //  Debug.Log("No ground detected within distance.");
        }

        // Optional: Draw the ray in the Scene view
        Debug.DrawRay(transform.position, Vector3.down * checkDistance, Color.red);

    }


    public void PlayerJump()
    {
 
        
        
    

        if (jmp > 0 && !GetComponent<Wallcheck>().HitsWall)
        {
            transform.Translate(Vector3.up * StartDist * (Time.deltaTime));
            OnGround = false;

            

            GetComponentInChildren<NessieAnimations>().ChangeStates(NessieState.Jumping);
            if (SFXManager)
            {
                SFX.PlayClipAudio(0);
            }
            else { GetComponent<AudioSource>().Play(); }

            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpStrength);
            jmp--;
        }


    }

   public void Springjump(float Strength)
    {

        if (!GetComponent<Wallcheck>().HitsWall)
        {
            transform.Translate(Vector3.up * StartDist * (Time.deltaTime));

            GetComponentInChildren<NessieAnimations>().ChangeStates(NessieState.Jumping);
            if (SFXManager)
            {
                SFX.PlayClipAudio(3);
            }
            else { GetComponent<AudioSource>().Play(); }
            OnGround = false;

            GetComponent<Rigidbody>().AddForce(Vector3.up * Strength);
            jmp--;
        }

    }
}
