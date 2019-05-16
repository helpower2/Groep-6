using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStats : MonoBehaviour
{
    [SerializeField] private float speed;//100 is normal, 150 very fast, 80 slow
    [SerializeField] private float health;//20 is defualt // 40 is buff // 60 is boss;
    [SerializeField] private float cost; //the cost per hour of work, 15 is low, 25 is normal, 35 is high
    [SerializeField] private float damage; //

    [SerializeField] private List<GameObject> equipment;// maak dit naar een enum als je het later gaat gebruiken 
    
    public float Speed { get { return speed; } }
    public float Health { get { return health; } }
    public float Cost { get { return cost; } }
    public float Damage { get { return damage; } }
    public List<GameObject> Equipment { get { return equipment; } }
}
