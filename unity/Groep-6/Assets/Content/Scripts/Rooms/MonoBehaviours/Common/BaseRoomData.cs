﻿using UnityEngine;
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
        storage

    }

    public BackgroundSprite backgroundSprite = 0;
    public ContentSprite contentSprite = (ContentSprite)0;

    public GameObject backgroundSpriteObject;
    public GameObject contentSpriteObject;

    public Vector2 position;

    public void Initialize(ContentSprite contentSprite)
    {
        BackgroundSprite backgroundSprite = 0;
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