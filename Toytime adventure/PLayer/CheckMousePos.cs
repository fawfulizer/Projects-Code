using Lean.Touch;
using UnityEngine;
using UnityEngine.Playables;

public class CheckMousePos : MonoBehaviour
{

    public bool Checking;
    //how long it can check
    public float CheckTime;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//reset timer
        if (Checking)
        {
            timer += Time.deltaTime;
            if(timer >= CheckTime ) {
                Checking = false;
                timer -= CheckTime;
                
            
            }
        }

       // transform.position = new Vector3(transform.position.x, transform.position.y,0);
    }

    public void CheckMousePosit()
    {
        if (!Checking)
        {
            timer = 0;
            Checking = true;
        }
      
    }

    private void OnTriggerStay(Collider other)
    {
        if ( Checking )
        {
          //  Debug.Log("I am hitting it!");  
            //player collision
            if (other.CompareTag("LeftMove")){
                //set direction
                var play = other.GetComponentInParent<PLayerMoveVertical>();
                play.PlayerMoveState = PState.left;
                    //makes it move
                 play.AllowMove(true);
                Checking = false;
                        
                    

            }
            else       //player collision
            if (other.CompareTag("RightMove"))
            {
                //set direction
                var play = other.GetComponentInParent<PLayerMoveVertical>();
                play.PlayerMoveState = PState.right;
                //makes it move
                play.AllowMove(true);
                                Checking = false;




            }


        }
    }


}
