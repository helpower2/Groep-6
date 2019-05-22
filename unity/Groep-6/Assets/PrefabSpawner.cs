
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public StoreQueue Store;
    public GameObject Prefab;
    public List<GameObject> Spawned = new List<GameObject>();
    private float spawn;
    public Vector2 time;
    private void Update()
    {
        spawn -= Time.deltaTime;
        if (spawn <= 0)
        {
            Debug.Log("Spawing");
            spawn = Random.Range(time.x, time.y);
            GameObject go = Instantiate<GameObject>(Prefab, this.transform);
            Customer gocust = go.GetComponent<Customer>();
            Spawned.Add(go);
            gocust.SetStore(Store);// note this is bad fix this
        }
    }
}
