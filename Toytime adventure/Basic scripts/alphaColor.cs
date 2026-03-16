using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alphaColor : MonoBehaviour
{
   Color c;
    [SerializeField]
    float FadeSpeed;
    SpriteRenderer Spr;
    // Start is called before the first frame update
    void Start()
    {
       // c =GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Spr = GetComponent<SpriteRenderer>();
        if (Spr != null) {
            c = GetComponent<SpriteRenderer>().color;
            var alp = GetComponent<SpriteRenderer>().color.a - FadeSpeed;
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alp);
        }
        else
        {
            c = GetComponent<Image>().color;
            var alp = GetComponent<Image>().color.a - FadeSpeed;
            GetComponent<Image>().color = new Color(c.r, c.g, c.b, alp);

        }
    }
}
