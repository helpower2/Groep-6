using UnityEngine;
[System.Serializable, RequireComponent(typeof(BaseRoomData))]
public class EmptyRoomData : MonoBehaviour
{
    [HideInInspector]
    public BaseRoomData roomData;
    public void Start()
    {
        roomData = gameObject.AddComponent<BaseRoomData>();
        roomData.Initialize(BaseRoomData.ContentSprite.emtpy);
    }
}