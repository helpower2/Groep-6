using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseRoomData))]
public class StorageRoom : MonoBehaviour
{
    [HideInInspector] public BaseRoomData roomData;

    [SerializeField] private List<StoragePoint> storagePoints = new List<StoragePoint>();


    private void Awake()
    {
        roomData = GetComponent<BaseRoomData>();
        roomData.Initialize(BaseRoomData.ContentSprite.storage);
        foreach (var point in GetComponentsInChildren<StoragePoint>())
        {
            storagePoints.Add(point);
        }
        storagePoints.TrimExcess();
    }

    public bool SpaceLeft()
    {
        foreach (StoragePoint storagePoint in storagePoints)
        {
            if (storagePoint.Storage == StorageType.Type.Empty)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsItemInStorage(StorageType.Type type)
    {
        foreach (StoragePoint storagePoint in storagePoints.ToArray())
        {
            if (storagePoint.Storage == type)
            {
                return true;
            }
        }
        return false;
    }

    public bool AddItem(StorageType.Type type)
    {
        var storage = GetFreeStoragePoint();
        if (storage == null) return false;
        storage.Storage = type;
        return true;
    }

    public bool GetItemFromStorage(StorageType.Type type)
    {
        foreach (StoragePoint storagePoint in storagePoints.ToArray())
        {
            if (storagePoint.Storage == type)
            {
                storagePoint.Storage = StorageType.Type.Empty;
                return true;
            }
        }
        return false;
    }

    private StoragePoint GetFreeStoragePoint()
    {
        foreach (StoragePoint storagePoint in storagePoints.ToArray())
        {
            if (storagePoint.Storage == StorageType.Type.Empty)
            {
                return storagePoint;
            }
        }
        return null;
    }
}

