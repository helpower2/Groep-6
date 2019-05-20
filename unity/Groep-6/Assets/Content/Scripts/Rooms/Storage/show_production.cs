using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_production : MonoBehaviour
{


    private Text ProductDisplay;
    int TotalUse;
    

    void Start()
    {
        
        TotalUse = 3;
       ProductDisplay = GetComponent<Text>();
        
    }


    void Update()
    {
        ProductDisplay.text = "your productions = " + TotalUse.ToString();
    }


}