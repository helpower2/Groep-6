using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sellable : MonoBehaviour
{
    public int price;

    public void SellRoom()
    {
        //Money.instance.TotalMoney += price;
        GameObject room = gameObject;
        RoomHandler roomHandler = FindObjectOfType<RoomHandler>();
        var newRoom = GameObject.Instantiate(roomHandler.emptyRoomPrefab, GameObject.FindGameObjectWithTag("RoomGrid").transform);
        newRoom.transform.position = room.transform.position;
        Destroy(room);
        roomHandler.InitializeGrid();
        roomHandler.UpdateBackgroundSprites();
    }
}
