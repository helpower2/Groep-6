using UnityEngine;
[System.Serializable, RequireComponent(typeof(BaseRoomData))]
public class EmptyRoomData : MonoBehaviour
{
    [HideInInspector]
    public BaseRoomData roomData;
    private int[] prices = new int[2] { 20, 50 };
    public void Start()
    {
        roomData = gameObject.GetComponent<BaseRoomData>();
        roomData.Initialize(BaseRoomData.ContentSprite.emtpy);
    }

    public void BuyRoom(int roomIndex)
    {
        if (/*Money.instance.TotalMoney >= price*/ true)
        {
            //Money.instance.TotalMoney -= price;

            GameObject room = gameObject;
            RoomHandler roomHandler = FindObjectOfType<RoomHandler>();
            var newRoom = new GameObject();
            switch (roomIndex)
            {
                case 0:
                    newRoom = GameObject.Instantiate(roomHandler.storageRoomPrefab, GameObject.FindGameObjectWithTag("RoomGrid").transform);
                    break;
                case 1:
                    newRoom = GameObject.Instantiate(roomHandler.weedPlantationRoomPrefab, GameObject.FindGameObjectWithTag("RoomGrid").transform);
                    break;
            }
            newRoom.transform.position = room.transform.position;
            Destroy(room);
            roomHandler.InitializeGrid();
            roomHandler.UpdateBackgroundSprites();
        }
    }
}