using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomHandler : MonoBehaviour
{
    GameObject[,] roomGrid;

    private void Start()
    {
        InitializeGrid();
        UpdateBackgroundSprites();
    }
    void InitializeGrid()
    {
        List<GameObject> Rooms = GameObject.FindGameObjectsWithTag("Room").ToList();

        Vector2Int highest = new Vector2Int(0, 0);
        Vector2Int lowest = new Vector2Int(99, 99);

        foreach (var room in Rooms)
        {
            var pos = room.GetComponent<Transform>().position;
            var x = Mathf.RoundToInt(pos.x);
            var y = Mathf.RoundToInt(pos.y * -1);
            highest.x = x > highest.x ? x : highest.x;
            highest.y = y > highest.y ? y : highest.y;
            lowest.x = x < lowest.x ? x : lowest.x;
            lowest.y = y < lowest.y ? y : lowest.y;
        }
        var gridSize = highest - lowest + new Vector2Int(1, 1);
        roomGrid = new GameObject[gridSize.x, gridSize.y];
        foreach (var room in Rooms)
        {
            var pos = room.GetComponent<Transform>().position;
            Vector2Int worldPos = new Vector2Int();
            worldPos.x = Mathf.RoundToInt(pos.x);
            worldPos.y = Mathf.RoundToInt(pos.y * -1);
            var posInGrid = convertWorldSpaceToGridSpace(lowest, worldPos);
            roomGrid[posInGrid.x, posInGrid.y] = room;
        }
    }
    /// <summary>
    /// Updates room backgrounds contextually
    /// <para>
    /// loops through the whole grid to update all background sprites
    /// </para>
    /// </summary>
    void UpdateBackgroundSprites()
    {
        for (int x = 0; x < roomGrid.GetLength(0); x++)
        {
            for (int y = 0; y < roomGrid.GetLength(1); y++)
            {
                SwitchRoomBackgroundSprite(x, y);
            }
        }
    }

    /// <summary>
    /// Updates 1 single given room background contextually
    /// </summary>
    void UpdateBackgroundSprites(int x, int y)
    {
        SwitchRoomBackgroundSprite(x, y);
    }
    Vector2Int convertWorldSpaceToGridSpace(Vector2Int lowest, Vector2Int worldSpace)
    {
        return worldSpace - lowest;
    }

    void SwitchRoomBackgroundSprite(int x, int y)
    {
        if (roomGrid[x, y] != null)
        {
            var _ref = roomGrid[x, y].GetComponent<BaseRoomData>();
            if (PointHasRoom(x - 1, y) && PointHasRoom(x + 1, y))
            {
                _ref.backgroundSprite = BaseRoomData._backgroundSprite.leftDoor_RightDoor;
            }
            else if (PointHasRoom(x - 1, y) && !PointHasRoom(x + 1, y))
            {
                _ref.backgroundSprite = BaseRoomData._backgroundSprite.leftDoor_RightWall;
            }
            else if (!PointHasRoom(x - 1, y) && PointHasRoom(x + 1, y))
            {
                _ref.backgroundSprite = BaseRoomData._backgroundSprite.leftWall_RightDoor;
            }
            else
            {
                _ref.backgroundSprite = BaseRoomData._backgroundSprite.leftWall_RightWall;
            }
            _ref.ConstructRoom();
        }
        else
        {
            Debug.LogWarning("Wrong room grid index given");
        }
    }
        
    bool PointHasRoom(int x, int y)
    {
        //make sure x isn't outside of array bounds
        if (x > roomGrid.GetLength(0) || x < 0)
        {
            return false;   
        }
        try
        {
            if (roomGrid[x, y] != null)
            {
                if (roomGrid[x, y].CompareTag("Room"))
                {
                    return true;
                }
            }
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }
        return false;
    }
}
