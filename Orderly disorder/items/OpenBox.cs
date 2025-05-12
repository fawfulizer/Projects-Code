using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class OpenBox : MonoBehaviour
{
    #region other objects/stuff
    [ Tooltip("Used to see if box is open or closed")]
    public bool isOpen;

    [SerializeField, Tooltip("Used to enable/disable picking up")]
    XRGrabInteractable InteractSript;

    [SerializeField, Tooltip("Used to enable/disable objects")]
    GameObject Objects;
    #endregion
    //Different mats so that when testing it is clear when the box is opened or closed
    #region debug stuff
    [SerializeField]
    Material MatClosed;
    [SerializeField]
    Material MatOpened;
    MeshRenderer CurrentMat;
    #endregion
    //Gets the reference
    [SerializeField,Tooltip("The Vr Origin Rig button used for the interaction")] InputActionReference BoxOpenButton;


    #region XR Button stuff
    //checks if hovering over box
    bool isoff =true;
    XRRayInteractor Raycast;
    #endregion

    #region hitbox and stuff
    BoxCollider Hitbox;
    Rigidbody Rigid;
    #endregion
    // Start is called before the first frame update

    Animator animator;
    void Start()
    {
        //gets materials
      
        InteractSript = GetComponent<XRGrabInteractable>();
        //Buttons
        //Fires the event for the button pressed
        BoxOpenButton.action.performed += BoxChange;
        Raycast = GetComponent<XRRayInteractor>();
        Hitbox = GetComponent<BoxCollider>();
        Rigid = GetComponent<Rigidbody>();
        //Gets the animator
        animator = GetComponentInChildren<Animator>();
    }

  

    // Update is called once per frame
    void Update()
    {
    

        
        //when closed allow the player to move box
        if(isOpen) 
        {
            //Sets the subscrived void to open
           // BoxOpenButton.action.started += DebugClosed;
            
             InteractSript.enabled = false;
            Hitbox.enabled = false;
            Rigid.isKinematic = true;
            // DebugOpen();
            //opens the box
            animator.SetBool("IsOpening", true);
        }
        else
        {
            //Sets the subscrived void to closed
           // BoxOpenButton.action.started += DebugOpen;
            InteractSript.enabled = true;
            Hitbox.enabled = true;
            Rigid.isKinematic = false;
            //closes the box
            animator.SetBool("IsOpening", false);
            // DebugClosed();
        }

    }


    private void BoxChange(InputAction.CallbackContext context)
    {
        //if hovering over box
        if (!isoff)
        {
            //if box is open
            if (isOpen)
            {
                //set box to closed
                isOpen = false;
              
              
               // Debug.Log($"I[ am currently closed");
            }
            //if box is closed
            else
            {
                //set box to opened
                isOpen = true;
               
                
                //Debug.Log($"I[ am currently Open");
            }
        }
    }








  

    private void OnTriggerStay(Collider other)
    {//used to see if box hitbox is overlapping
        //when colliding with box Hitbox
        if (other.gameObject.CompareTag("BoxInteractor"))
        {
            
            isoff = false;
          //  Debug.Log($"Flag = {isoff.ToString()}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BoxInteractor"))
        {

            isoff = true;
           // Debug.Log($"Flag = {isoff.ToString()}");

        }
    }
}


