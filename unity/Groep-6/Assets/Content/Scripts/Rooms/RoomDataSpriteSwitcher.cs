using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class RoomDataSpriteSwitcher
{
    private static SpriteReferences spriteReferences;

    static RoomDataSpriteSwitcher()
    {
        spriteReferences = GameObject.FindObjectOfType<SpriteReferences>();
    }



    public static Sprite returnContentSprite(BaseRoomData._contentSprite contentSprite)
    {
        switch (contentSprite)
        {
            case BaseRoomData._contentSprite.emtpy:
                return null;
            case BaseRoomData._contentSprite.stairs:
                return spriteReferences.stairs;
            case BaseRoomData._contentSprite.weedPlantation:
                return spriteReferences.weedPlantation;
            case BaseRoomData._contentSprite.drugLab:
                return spriteReferences.drugLab;
        }
        return null;
    }

    public static Sprite returnBackgroundSprite(BaseRoomData._backgroundSprite backgroundSprite)
    {
        switch (backgroundSprite)
        {
            case BaseRoomData._backgroundSprite.blank:
                return spriteReferences.blank;
            case BaseRoomData._backgroundSprite.leftDoorRightDoor:
                return spriteReferences.leftDoorRightDoor;
            case BaseRoomData._backgroundSprite.leftDoorRightWall:
                return spriteReferences.leftDoorRightWall;
            case BaseRoomData._backgroundSprite.leftWallRightDoor:
                return spriteReferences.leftWallRightDoor;
            case BaseRoomData._backgroundSprite.leftWallRightWall:
                return spriteReferences.leftWallRightDoor;
        }
        return null;
    }

}
