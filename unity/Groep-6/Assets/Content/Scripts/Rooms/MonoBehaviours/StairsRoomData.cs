using UnityEngine;
[System.Serializable, RequireComponent(typeof(BaseRoomData))]
public class StairsRoomData : MonoBehaviour
{
    [HideInInspector]
    public BaseRoomData roomData;
    public void Awake()
    {
        roomData = gameObject.GetComponent<BaseRoomData>();
        roomData.Initialize(BaseRoomData.ContentSprite.stairs);
    }

    public void ExpandStairs()
    {
        RoomHandler roomHandler = FindObjectOfType<RoomHandler>();
        var cords = roomHandler.returnRoomGrid(gameObject);
        Debug.Log("room status" + roomHandler.PointHasRoom(cords[0], cords[1]));
        int yDif = 1;
        bool roomFound = false;
        while (!roomFound)
        {
            if (!roomHandler.PointHasRoom(cords[0], cords[1] + yDif))
            {
                roomFound = true;
                var pos = roomHandler.roomGrid[cords[0], cords[1] + yDif - 1].transform.position;
                var newRoom = GameObject.Instantiate(roomHandler.stairsRoomPrefab, GameObject.FindGameObjectWithTag("RoomGrid").transform);
                newRoom.transform.position = new Vector3(pos.x, pos.y - 1, pos.z);
                roomHandler.InitializeGrid();
                roomHandler.UpdateBackgroundSprites();
            }
            else
            {
                yDif++;
            }
        }
    }
}