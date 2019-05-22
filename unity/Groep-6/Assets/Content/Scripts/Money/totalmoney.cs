using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalmoney : MonoBehaviour
{


    private Text moneyDisplay;
    

    void Start()
    {

        moneyDisplay = GetComponent<Text>();

        //als money woord geroept dan veranderen al code die aan dit vast zit
        
        Money.instance.onValueChange += (float money) => { MoneyCount(); };
    }


    void MoneyCount()
    {
        //in money display word je geld uit gespewd
        moneyDisplay.text = "your money = " + Money.instance.TotalMoney.ToString();
    }


}