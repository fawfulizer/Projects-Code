using System;
using UnityEngine;

public class GyroPlayer : MonoBehaviour
{

    public Material ActiveMat;
    public Material InactiveMat;
    public Material ScreenActive;
    public Material ScreenInactive;


    public SkinnedMeshRenderer Light;
    public bool Active;
    public CustomGravity GyroScript;


    NessieAnimations ness;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ness = GetComponent<NessieAnimations>();
        ness.animator.SetBool("Active", false);
        ness.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        var MAts = Light.materials;
        if(Active) {
            MAts[0] = ActiveMat;
            MAts[1] = ScreenActive;
            Light.materials = MAts;
            ness.enabled = true;
            ness.animator.SetBool("Active", true);


        } else
        {
            ness.animator.SetBool("Active", false);
            ness.enabled = false;


            MAts[0] = InactiveMat;
            MAts[1] = ScreenInactive;
            Light.materials = MAts;

        }

        GyroMove();
    }


    public void CHangeSelect()
    {
        Active = !Active;
        Debug.LogWarning("PAUSING GAME");

    }
    private void GyroMove()
    {
        if (FindFirstObjectByType<LevelManager>().UseGyro) { 
        if(Active)
            {
                GyroScript.enabled = true;
                ness.State = NessieState.Walking;

            }
            else
            {
                GyroScript.enabled = false;
                ness.State = NessieState.Idle;

            }
        
        
        }
        #region rotations
        if (Active)
        {
            if (GyroScript.gravityDirection.y < 0.1f)
            {
                var move = GetComponent<PLayerMoveVertical>();

                move.Visual.transform.rotation = Quaternion.Euler(0, move.RightRot, 0);



            }
            else
            {
                var move = GetComponent<PLayerMoveVertical>();

                move.Visual.transform.rotation = Quaternion.Euler(0, move.LeftRot, 0);
            }
        }
        #endregion

    }

}
