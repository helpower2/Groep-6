using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{


    private Text moneyDisplay;


     void Start()
    {

        moneyDisplay = GetComponent<Text>();
        Money.instance.onValueChange += (float money) => { MoneyCount(); };
    }

   
    void MoneyCount()
    {
       moneyDisplay.text="your money = "+ Money.instance.TotalMoney.ToString(); 
    }

   
}
