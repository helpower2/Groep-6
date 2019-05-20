
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public StoreQueue Store;
    public GameObject Prefab;
    private float spawn;
    public float time;
    private void Update()
    {
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            Debug.Log("Spawing");
            spawn = time;
            GameObject go = Instantiate<GameObject>(Prefab, this.transform);
            Customer gocust = go.GetComponent<Customer>();

            gocust.SetStore(Store);// note this is bad fix this
        }
    }
}
