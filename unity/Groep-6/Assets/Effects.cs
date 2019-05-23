using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : Singleton<Effects>
{
    struct eff
    {
         public bool effects;
    }
    private eff effectsSave;
    public bool effects => effectsSave.effects;

    private void Awake()
    {
        Instance();
        //effectsSave.load("effects");
        effectsSave.load();
        //DataManager.Load<eff>(ref effectsSave, "effects");
    }


    [SerializeField] private float strength = 0.1f;
    public void Effect_Shake(Customer Cust)
    {
        //Debug.Log("shake");
        if (effects)
        {
            Cust.transform.Effect_Shake(1f, strength);
        }
    }
    private void OnDisable()
    {
        //effectsSave.Save("Effects");
        effectsSave.Save();
        //DataManager.Save <eff>(effectsSave, "effects");
    }
}
