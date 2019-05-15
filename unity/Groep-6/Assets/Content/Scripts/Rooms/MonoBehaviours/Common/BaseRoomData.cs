using UnityEngine;
[System.Serializable, SerializeField]
public class BaseRoomData : MonoBehaviour, IRoom
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
        drugLab,
        storage

    }

    public _backgroundSprite backgroundSprite = 0;
    public _contentSprite contentSprite = (_contentSprite)0;

    public GameObject backgroundSpriteObject;
    public GameObject contentSpriteObject;

    public Vector2 position;

    public void Initialize(_contentSprite contentSprite)
    {
        _backgroundSprite backgroundSprite = 0;
        Vector2 position = transform.position;
        GameObject backgroundSpriteObject = transform.GetChild(0).GetChild(1).gameObject;
        GameObject contentSpriteObject = transform.GetChild(0).GetChild(0).gameObject;
        this.backgroundSprite = backgroundSprite;
        this.contentSprite = contentSprite;
        this.backgroundSpriteObject = backgroundSpriteObject;
        this.contentSpriteObject = contentSpriteObject;
        this.position = position;
    }

    public void ConstructRoom()
    {
        contentSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnContentSprite(contentSprite);
        backgroundSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnBackgroundSprite(backgroundSprite);
    }

}
