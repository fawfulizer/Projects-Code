using UnityEngine;
public enum PState
{
    idle,
    right,
    left


};
public class PLayerMoveVertical : MonoBehaviour
{
    public float MoveSPeed = 3;
   
    public bool CanMove;

    public PState PlayerMoveState;

    [SerializeField]
  public  GameObject Visual;
    //animations
    NessieAnimations animator;

    public float RightRot = 90;
    public float LeftRot = 270;
    public bool JumpMovable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<NessieAnimations>();
        if(animator == null)
        {

            animator = GetComponentInChildren<NessieAnimations>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMoveState == PState.left)
        {
            MoveLeft();

        }
        else if(PlayerMoveState == PState.right)
        {

            MoveRight();
        }
    }

    public void MoveRight()
    {
        //springman
        if(JumpMovable) {
            if (CanMove)
            {
                PlayerMoveState = PState.right;

                transform.Translate(new Vector3(MoveSPeed * Time.deltaTime, 0, 0));

                //change animations
                if (animator != null)
                {
                    animator.ChangeStates(NessieState.Walking);
                    Visual.transform.rotation = Quaternion.Euler(0, RightRot, 0);
                }

            }
        }
        //normal
        else
        {
            if (CanMove && GetComponent<Jump>().OnGround)
            {
                PlayerMoveState = PState.right;

                transform.Translate(new Vector3(MoveSPeed * Time.deltaTime, 0, 0));

                //change animations
                if (animator != null)
                {
                    animator.ChangeStates(NessieState.Walking);
                    Visual.transform.rotation = Quaternion.Euler(0, RightRot, 0);
                }

            }

        }
       
    }

    public void MoveLeft() {
        //springman    
        if (JumpMovable)
            {

                if (CanMove)
                {
                    PlayerMoveState = PState.left;
                    transform.Translate(new Vector3(-MoveSPeed * Time.deltaTime, 0, 0));

                    //change animations
                    if (animator != null)
                    {
                        Visual.transform.rotation = Quaternion.Euler(0, LeftRot, 0);
                        animator.ChangeStates(NessieState.Walking);

                    }
                }
            }
        //normal
        else
        {
            if (CanMove && GetComponent<Jump>().OnGround)
            {
                PlayerMoveState = PState.left;
                transform.Translate(new Vector3(-MoveSPeed * Time.deltaTime, 0, 0));

                //change animations
                if (animator != null)
                {
                    Visual.transform.rotation = Quaternion.Euler(0, LeftRot, 0);
                    animator.ChangeStates(NessieState.Walking);

                }
            }
        }
        }



    public void StopPlayer()
    {if (GetComponent<Jump>().OnGround)
        {
            CanMove = false;
            PlayerMoveState = PState.idle;
            // Debug.Log("Stopping");

            //change animations
            if (animator != null)
            {
                animator.ChangeStates(NessieState.Idle);

            }
        }
    }

    public void AllowMove(bool move)
    {
        CanMove= move;

    }
}
