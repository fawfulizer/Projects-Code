using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{public enum ButtonType
    {
        Basic,
        Gyro,
        Boss


    }
    
    public List<Sprite> Buttontypes;
    public ButtonType SPriteType;

    TextMeshProUGUI LevelNumber;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelNumber = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = Buttontypes[(int)SPriteType];
    }

    public void ChangeType(ButtonType t, int number)
    {
        //change icon type
        SPriteType= t;

        LevelNumber.text = number.ToString();
    }

}
