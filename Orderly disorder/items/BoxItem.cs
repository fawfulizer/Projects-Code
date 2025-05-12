using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
    // Start is called before the first frame update
    //The script to check if box is open
    OpenBox BoxScript;
    [SerializeField]
    GameObject Child;
    void Start()
    {
        BoxScript = GetComponent<OpenBox>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!BoxScript.isOpen) {
            Child.SetActive(false);
        } else Child.SetActive(true);
    }
}
