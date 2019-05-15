using UnityEngine;
[System.Serializable, SerializeField]
public class BaseRoomData : MonoBehaviour, IRoom
{
    public enum BackgroundSprite
    {
        blank,
        leftDoor_RightDoor,
        leftDoor_RightWall,
        leftWall_RightDoor,
        leftWall_RightWall,
    }

    public enum ContentSprite
    {
        emtpy,
        stairs,
        weedPlantation,
        drugLab,
        storage,
        sellRoom

    }

    public BackgroundSprite backgroundSprite = 0;
    public ContentSprite contentSprite = (ContentSprite)0;

    //holds a reference to the background and content gameObjects of each room
    public GameObject backgroundSpriteObject;
    public GameObject contentSpriteObject;

    public Vector2 position;

    public void Initialize(ContentSprite contentSprite)
    {
        this.contentSprite = contentSprite;
        this.position = transform.position;
    }
    /// <summary>
    /// Updates content and background sprites to reflect the current content and background enum values
    /// </summary>
    public void ConstructRoom()
    {
        contentSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnContentSprite(contentSprite);
        backgroundSpriteObject.GetComponent<SpriteRenderer>().sprite = RoomDataSpriteSwitcher.returnBackgroundSprite(backgroundSprite);
    }

}