using UnityEngine;
/// <summary>
/// Holds public references to room sprites
/// </summary>
public class SpriteReferences : MonoBehaviour
{
    [Header("Room doors")]
    public Sprite blank,
                     leftDoorRightDoor,
                     leftDoorRightWall,
                     leftWallRightDoor,
                     leftWallRightWall;

    [Header("Room Sprites")]
    public Sprite empty,
                     stairs,
                     weedPlantation,
                     drugLab,
                     storage,
                     sellRoom;
    [Header("Storage Sprites")]
    public Sprite Weed;
}
