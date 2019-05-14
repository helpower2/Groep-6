using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DrugLabRoomData : MonoBehaviour, IRoom
{
    [System.Serializable]
    public class RoomData : BaseRoomData
    {
        public _backgroundSprite backgroundSprite = 0;
        public _contentSprite contentSprite = (_contentSprite)3;

        public GameObject backgroundSpriteObject;
        public GameObject contentSpriteObject;

        public Vector2 position;
    }
    public RoomData roomData = new RoomData();

    private void OnValidate()
    {
        roomData.position = this.GetComponent<Transform>().position;
    }
    public void Start()
    {
        ConstructRoom();
        roomData.position = this.GetComponent<Transform>().position;
    }
    public void ConstructRoom()
    {
        roomData.contentSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnContentSprite(roomData.contentSprite);
        roomData.backgroundSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnBackgroundSprite(roomData.backgroundSprite);
    }
}