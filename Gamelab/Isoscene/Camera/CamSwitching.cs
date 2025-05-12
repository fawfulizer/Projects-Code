using System;
using UnityEngine;

public class CamSwitching : MonoBehaviour
{
    [SerializeField]
    Camera ISOCAM;
    [SerializeField]
    Camera FPCAM;
    [SerializeField]
    bool isIso;
    [SerializeField]
    GameObject Transition;
    [SerializeField]
    GameObject IsoStuff;
    [SerializeField]
    GameObject FpStiff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //setup
        CamSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if(Input.GetKeyDown(KeyCode.D))
        {
            CamSwitch();

        }

        
    }

    //the actual switching
    public void CamSwitch() {
     if(isIso)
        {
            FPCAM.gameObject.SetActive(false);
            ISOCAM.gameObject.SetActive(true);
            FpStiff.gameObject.SetActive(false);
            IsoStuff.gameObject.SetActive(true);
            Trans();
            isIso = false;

        }
        else
        {
            FPCAM.gameObject.SetActive(true);
            ISOCAM.gameObject.SetActive(false);
            FpStiff.gameObject.SetActive(true);
            IsoStuff.gameObject.SetActive(false);
            Trans();
            isIso = true;
        }
    
    
    }

    private void Trans()
    {
        Transition.SetActive(true);
    }
}
