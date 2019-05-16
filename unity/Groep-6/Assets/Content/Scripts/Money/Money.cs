using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static Money instance;

    public Action<float> onValueChange = delegate { };

    [SerializeField]
    //The amount of money the player has
    float totalMoney;

    public float TotalMoney
    {
        get { return totalMoney; }
        set { totalMoney = value; }
    }

    void Awake()
    {
        instance = this;
    }
}
