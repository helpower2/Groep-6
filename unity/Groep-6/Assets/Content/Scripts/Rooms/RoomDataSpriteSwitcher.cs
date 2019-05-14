using UnityEngine;

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
            case BaseRoomData._backgroundSprite.leftDoor_RightDoor:
                return spriteReferences.leftDoorRightDoor;
            case BaseRoomData._backgroundSprite.leftDoor_RightWall:
                return spriteReferences.leftDoorRightWall;
            case BaseRoomData._backgroundSprite.leftWall_RightDoor:
                return spriteReferences.leftWallRightDoor;
            case BaseRoomData._backgroundSprite.leftWall_RightWall:
                return spriteReferences.leftWallRightDoor;
        }
        return null;
    }

}
