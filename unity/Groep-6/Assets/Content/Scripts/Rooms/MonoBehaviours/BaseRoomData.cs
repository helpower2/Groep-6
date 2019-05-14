using UnityEngine;
[System.Serializable]
public class BaseRoomData : IRoom
{
    public enum _backgroundSprite
    {
        blank,
        leftDoor_RightDoor,
        leftDoor_RightWall,
        leftWall_RightDoor,
        leftWall_RightWall,
    }

    public enum _contentSprite
    {
        emtpy,
        stairs,
        weedPlantation,
        drugLab
    }

    public _backgroundSprite backgroundSprite = 0;
    public _contentSprite contentSprite = (_contentSprite)0;

    public GameObject backgroundSpriteObject;
    public GameObject contentSpriteObject;

    public Vector2 position;

    public BaseRoomData(_contentSprite contentSprite, GameObject backgroundSpriteObject, GameObject contentSpriteObject, Vector2 position)
    {
        _backgroundSprite backgroundSprite = 0;

        this.backgroundSprite = backgroundSprite;
        this.contentSprite = contentSprite;
        this.backgroundSpriteObject = backgroundSpriteObject;
        this.contentSpriteObject = contentSpriteObject;
        this.position = position;
    }

    public void ConstructRoom(int content, int background)
    {
        contentSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnContentSprite((_contentSprite)content);
        backgroundSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnBackgroundSprite((_backgroundSprite)background);
    }

}
