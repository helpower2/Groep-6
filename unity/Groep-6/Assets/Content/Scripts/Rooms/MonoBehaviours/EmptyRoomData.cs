using UnityEngine;
[System.Serializable, RequireComponent(typeof(BaseRoomData))]
public class EmptyRoomData : MonoBehaviour
{
    [HideInInspector]
    public BaseRoomData roomData;
    public void Start()
    {
        Vector2 position = transform.position;
        GameObject backgroundSpriteObject = transform.GetChild(0).GetChild(1).gameObject;
        GameObject contentSpriteObject = transform.GetChild(0).GetChild(0).gameObject;
        roomData = gameObject.AddComponent<BaseRoomData>();
        roomData.Constructor(BaseRoomData._contentSprite.emtpy, backgroundSpriteObject, contentSpriteObject, position);
    }
}