using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInterFace : MonoBehaviour
{
    private StorageRooms storageRooms;
    // Start is called before the first frame update
    void Start()
    {
        storageRooms = GetComponentInParent<StorageRooms>();
        if (storageRooms == null)
        {
            Debug.LogError("No StorageRooms Found.");
        }
    }

    public void AddItem(int type)
    {
        storageRooms.AddItem((StorageType.Type)type);
    }
    public bool GetItem(StorageType.Type type)
    {
        return storageRooms.GetItemFromStorage(type);
    }
    public bool IsSpaceLeft()
    {
        return storageRooms.SpaceLeft();
    }
}
