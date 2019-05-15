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
}