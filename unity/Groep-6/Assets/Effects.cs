using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : Singleton<Effects>
{
    public bool effects;

    private void Awake()
    {
        Instance();
        DataManager.Load<bool>(ref effects, "effects");
    }


    [SerializeField] private float strength = 0.1f;
    public void Effect_Shake(Customer Cust)
    {
        Debug.Log("shake");
        Cust.transform.Effect_Shake(1f, strength);
        
    }
}
