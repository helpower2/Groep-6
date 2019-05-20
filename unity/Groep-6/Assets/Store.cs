using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StoreQueue), typeof(HumansInRoom), typeof(StorageInterFace))]
public class Store : MonoBehaviour
{
    private StoreQueue storeQueue;
    private HumansInRoom humansInRoom;
    private StorageInterFace storageInterFace;
    private float lastSellTime;

    public float timePerSell;

    private void Start()
    {
        storageInterFace = GetComponent<StorageInterFace>();
        humansInRoom = GetComponent<HumansInRoom>();
        storeQueue = GetComponent<StoreQueue>();
        lastSellTime = 0;
    }

    private void Update()
    {
        float speed = 0;
        foreach (var human in humansInRoom.humanStats)
        {
            speed += human.Speed;
        }
        speed /= 100;
        Debug.Log("Speed: " + speed);
        if (!float.IsNaN(speed))
        {
            lastSellTime -= Time.deltaTime * speed;
        }
        
        if (lastSellTime <= 0)
        {
            Debug.Log("timer done");
            if (storeQueue.PeekCustomer() != null)
            {
                Debug.Log("Customer");
                Customer customer = storeQueue.GetCustomer();
                foreach (var item in customer.CustemerWants)
                {
                    Debug.Log("Items");
                    if (storageInterFace.GetItem(item))
                    {
                        //item sold
                        Money.instance.TotalMoney += StorageType.GetCost(item);
                        Debug.Log("Sold" + item.ToString());
                    }
                }
                Destroy(customer.gameObject);
                lastSellTime = timePerSell;
                
            }
        }
    }
}
