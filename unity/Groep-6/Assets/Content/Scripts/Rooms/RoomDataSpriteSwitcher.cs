using UnityEngine;
/// <summary>
/// returns a sprite from the <see cref="SpriteReferences"/> based on the enum given
/// </summary>
public static class RoomDataSpriteSwitcher
{
    //Reference to the SpriteReference script attached to the RoomHandler GameObject prefab
    private static SpriteReferences spriteReferences;

    static RoomDataSpriteSwitcher()
    {
        spriteReferences = GameObject.FindObjectOfType<SpriteReferences>();
    }

    public static Sprite returnContentSprite(BaseRoomData.ContentSprite contentSprite)
    {
        switch (contentSprite)
        {
            case BaseRoomData.ContentSprite.emtpy:
                return null;
            case BaseRoomData.ContentSprite.stairs:
                return spriteReferences.stairs;
            case BaseRoomData.ContentSprite.weedPlantation:
                return spriteReferences.weedPlantation;
            case BaseRoomData.ContentSprite.drugLab:
                return spriteReferences.drugLab;
            case BaseRoomData.ContentSprite.storage:
                return spriteReferences.storage;
        }
        return null;
    }

    public static Sprite returnBackgroundSprite(BaseRoomData.BackgroundSprite backgroundSprite)
    {
        switch (backgroundSprite)
        {
            case BaseRoomData.BackgroundSprite.blank:
                return spriteReferences.blank;
            case BaseRoomData.BackgroundSprite.leftDoor_RightDoor:
                return spriteReferences.leftDoorRightDoor;
            case BaseRoomData.BackgroundSprite.leftDoor_RightWall:
                return spriteReferences.leftDoorRightWall;
            case BaseRoomData.BackgroundSprite.leftWall_RightDoor:
                return spriteReferences.leftWallRightDoor;
            case BaseRoomData.BackgroundSprite.leftWall_RightWall:
                return spriteReferences.leftWallRightWall;
        }
        return null;
    }

}
