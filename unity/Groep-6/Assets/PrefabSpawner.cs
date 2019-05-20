using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public StoreQueue Store;
    public GameObject Prefab;
    private Timer timer;
    private bool spawn;
    private void Start()
    {
        timer = new Timer(5000);
        timer.Elapsed += Spawn;
        timer.Start();
    }
    private void Update()
    {
        if (spawn)
        {
            Debug.Log("Spawing");
            spawn = false;
            GameObject go = Instantiate<GameObject>(Prefab, this.transform);
            Customer gocust = go.GetComponent<Customer>();

            gocust.SetStore(Store);// note this is bad fix this
        }
    }

    private void Spawn(object sender, ElapsedEventArgs e)
    {
        Debug.Log("event");
        spawn = true;
        //throw new System.NotImplementedException();
    }
    private void OnDisable()
    {
        timer.Dispose();
    }
}
