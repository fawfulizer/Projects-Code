using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Snapitem : MonoBehaviour
{
    //[Tooltip("")]
    //Used to set the position to snap to.
    Vector3 SnapPos;
    GameObject SnapObject;
    [Tooltip("Used for item.")]
   public bool isStocked;
    //used to update the score
    public event UnityAction AddGood;
    Endresult ResultScript;
    #region item type
    //gets it's own itemtype
    itemTypes ItemScript;
    //Script to Get the hitbox types
    SnapHitBox SnapHitBox;
    [SerializeField, Tooltip("Used to offset the snapping point")]
    Vector3 SnapOffset = new Vector3(0, 5, 0);

    #endregion
    //for removing
    bool CorrectStocked;

    //Used for cooldown on replacing items, otherwise items becomes small?
    float MaxUnlockTImer=1;
    float UnlockTImer;
    bool isLocked;
    GameObject LatestSnapbox;
    // Start is called before the first frame update
    void Start()
    {
        ItemScript = GetComponent<itemTypes>();
        ResultScript = GameObject.FindWithTag("EndManager").GetComponent<Endresult>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStocked)
        {

            Rigidbody rb = (Rigidbody)gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            BoxCollider bx = gameObject.gameObject.GetComponent<BoxCollider>();
            bx.enabled = true;

            //locked timer
            if (isLocked)
            {
                UnlockTImer += Time.deltaTime;
                if(UnlockTImer >= MaxUnlockTImer)
                {

                    //enables grabScript
                    XRGrabInteractable Grabsscript = GetComponent<XRGrabInteractable>();
                    Grabsscript.enabled = true;
                    SnapHitBox = LatestSnapbox.gameObject.GetComponent<SnapHitBox>();
                    SnapHitBox.enabled = true;
                    //enables other hitbox
                    BoxCollider Hitbox = LatestSnapbox.GetComponent<BoxCollider>();
                    Hitbox.enabled = true;
                    //reset loop
                    SnapHitBox.CorrectLoop = false;
                    
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapPos"))
        {
            if (!isStocked)
            {
                #region unused
                /*
                   //gets the other object
                   SnapObject = other.gameObject;

                   //sets the snap pos
                   SnapPos = SnapObject.transform.position;

                   //Snaps to position 
                   gameObject.transform.position = SnapPos + SnapOffset;
                  */
                #endregion

                //adds to the amount
                ResultScript.Current_placed++;
                //rigidbody
                Rigidbody rb = (Rigidbody)gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
                BoxCollider bx = gameObject.gameObject.GetComponent<BoxCollider>();
                bx.enabled = false;


                #region Item types
                //gets the other object
                SnapHitBox = other.gameObject.GetComponent<SnapHitBox>();

                //if type is the same set CorrectItem to true.
                if ((int)ItemScript.type == (int)SnapHitBox.type)
                {
                    //sets the item to correct
                    SnapHitBox.CorrectItem = true;
                    CorrectStocked = true;
                    #region score
                    //gets the script
                    //Endresult endScript = GameObject.FindWithTag("").GetComponent<Endresult>();
                    //invokes the good event.
                    ResultScript.AddGoodAmount();
                    #endregion
                    Debug.Log($"Correct! Item = {ItemScript.type} and shelf = Item = {SnapHitBox.type}");
                }
                else
                //if type is wrong
                { Debug.Log($"Wrong! Item = {ItemScript.type} and shelf = Item = {SnapHitBox.type}"); }

                //disables collison
                // other.gameObject.SetActive(false);
                SnapHitBox.enabled = false;
                #endregion

                #region transferring parent
                //changes parent
                transform.parent = other.transform;
                gameObject.transform.localPosition = new Vector3(0, 0, 0);

                //disables grabScript
                XRGrabInteractable Grabsscript = GetComponent<XRGrabInteractable>();
                Grabsscript.enabled = false;
                isLocked = true;
                LatestSnapbox = other.gameObject;
                //disables other hitbox
                BoxCollider Hitbox = other.GetComponent<BoxCollider>();
                Hitbox.enabled = false;
                
                #endregion
                isStocked = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (isStocked)
        {
            if (other.CompareTag("SnapPos"))
        {

                ResultScript.Current_placed--;
             
          
            if (CorrectStocked) { }
            SnapHitBox = other.gameObject.GetComponent<SnapHitBox>();
            SnapHitBox.CorrectItem = false;
            CorrectStocked = false;
            ResultScript.SubGoodAmount();



            
            //rigidbody
            Rigidbody rb = (Rigidbody)gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            BoxCollider bx = gameObject.gameObject.GetComponent<BoxCollider>();
            bx.enabled = true;

            
            Debug.Log($"Item = {ItemScript.type} is removed from shelf = Item = {SnapHitBox.type},\n Current score is {ResultScript.correctAmount}");
                isStocked = false;
            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ItemBox") { 
            //resets parent 
        transform.parent = null;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ItemBox")
        {
            //resets parent 
            transform.parent = null;
        }
    }*/
   
}
