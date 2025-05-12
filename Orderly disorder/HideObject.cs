using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideObject : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer ObjectMesh;
    SpriteRenderer SpriteRender;
    Image ImageRender;
    void Start()
    {
        //gets the object
        ObjectMesh = GetComponent<MeshRenderer>();
        SpriteRender = GetComponent<SpriteRenderer>();
        ImageRender = GetComponent<Image>();
        if (ObjectMesh != null)
        {
            
            ObjectMesh.enabled = false;

        }

        if (SpriteRender != null)
        {
            
            SpriteRender.enabled = false;

        }

        if (ImageRender != null)
        {
            
            ImageRender.enabled = false;

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
