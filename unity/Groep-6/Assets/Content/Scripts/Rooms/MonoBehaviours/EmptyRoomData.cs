﻿using UnityEngine;
[System.Serializable, RequireComponent(typeof(BaseRoomData))]
public class EmptyRoomData : MonoBehaviour
{
    [HideInInspector]
    public BaseRoomData roomData;
    public void Start()
    {
        roomData = GetComponent<BaseRoomData>();
        Debug.Log(roomData);
        roomData.Initialize(BaseRoomData.ContentSprite.emtpy);
    }
}