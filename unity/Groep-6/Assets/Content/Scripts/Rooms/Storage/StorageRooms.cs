using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageRooms : MonoBehaviour
{
    [SerializeField] private List<StorageRoom> storageRooms = new List<StorageRoom>();

    private void Start()
    {
        foreach (var item in GetComponentsInChildren<StorageRoom>())
        {
            storageRooms.Add(item);
        }
    }

    public bool SpaceLeft()
    {
        foreach (StorageRoom room in storageRooms)
        {
            if (room.SpaceLeft())
            {
                return true;
            }
        }
        return false;
    }
    public bool IsItemInStorage(StorageType.Type type)
    {
        foreach (StorageRoom room in storageRooms)
        {
            if (room.IsItemInStorage(type))
            {
                return true;
            }
        }
        return false;
    }
    public bool AddItem (StorageType.Type type)
    {
        foreach (StorageRoom room in storageRooms)
        {
            if (room.AddItem(type))
            {
                return true;
            }
        }
        return false;
    }
    public bool GetItemFromStorage(StorageType.Type type)
    {
        foreach (StorageRoom room in storageRooms)
        {
            if (room.GetItemFromStorage(type))
            {
                return true;
            }
        }
        return false;
    }
}
