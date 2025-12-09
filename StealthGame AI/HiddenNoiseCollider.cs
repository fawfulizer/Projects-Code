using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenNoiseCollider : MonoBehaviour
{
    HiddenObject scrpt;
    public bool Hearable;
    // Start is called before the first frame update
    void Start()
    {
        scrpt = GetComponentInParent<HiddenObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Hearable = scrpt.MakesNoise;
    }
}
