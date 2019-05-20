using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private Vector2 Posision;
    private StoreQueue storeQueue;

    public List<StorageType.Type> CustemerWants { get; private set; } = new List<StorageType.Type>();

    private void OnEnable()
    {
        int r = Random.Range(1, 5);
        for (int i = 0; i < r; i++)
        {
            CustemerWants.Add((StorageType.Type)Random.Range(0, 1));
        }
    }
    public void SetPosision(Vector2 pos)
    {
        Posision = pos;
        Debug.Log(pos);
        transform.position = new Vector3(Posision.x, Posision.y, transform.position.z);
    }
    public void SetStore(StoreQueue _storeQueue)
    {
        storeQueue = _storeQueue;
        SetPosision(storeQueue.AddCustomerToLine(this));
    }
}
