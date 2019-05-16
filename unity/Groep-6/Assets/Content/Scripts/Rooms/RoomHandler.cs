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
    /// <summary>
    /// Constructs a grid array composed of the room objects
    /// </summary>
    void InitializeGrid()
    {
        //finds all rooms
        List<GameObject> Rooms = GameObject.FindGameObjectsWithTag("Room").ToList();
        //highest room position offset from the centre of the game found
        Vector2Int highest = new Vector2Int(0, 0);
        //lowest room position offset from the centre of the game found
        Vector2Int lowest = new Vector2Int(99, 99);

        //loops through all rooms
        foreach (var room in Rooms)
        {
            //gets the position of the room and rounds the x and y to individual variables
            var pos = room.transform.position;
            var x = Mathf.RoundToInt(pos.x);
            var y = Mathf.RoundToInt(pos.y * -1);
            //lowest and highest are set to their smallest or biggest values
            highest.x = x > highest.x ? x : highest.x;
            highest.y = y > highest.y ? y : highest.y;
            lowest.x = x < lowest.x ? x : lowest.x;
            lowest.y = y < lowest.y ? y : lowest.y;
        }
        //grid size is the difference between the lowest and highest with a 1 offset
        var gridSize = highest - lowest + new Vector2Int(1, 1);
        //initializes the room grid
        roomGrid = new GameObject[gridSize.x, gridSize.y];
        //populates the room grid
        foreach (var room in Rooms)
        {
            //gets the position of the room and populates the worldPos int vector with its rounded values
            var pos = room.transform.position;
            Vector2Int worldPos = new Vector2Int();
            worldPos.x = Mathf.RoundToInt(pos.x);
            worldPos.y = Mathf.RoundToInt(pos.y * -1);
            //posInGrid is the conversion of the world position to the grid position of the room
            var posInGrid = convertWorldSpaceToGridSpace(lowest, worldPos);
            //makes sure room reference is not overwritten
            if (roomGrid[posInGrid.x, posInGrid.y] == null)
            {
                roomGrid[posInGrid.x, posInGrid.y] = room;
            }
            else
            {
                Debug.LogWarning("position in grid : " + posInGrid + " is already populated");
            }
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
    //returns the grid indexes based on the world position of the room and the lowest offset
    Vector2Int convertWorldSpaceToGridSpace(Vector2Int lowest, Vector2Int worldSpace)
    {
        return worldSpace - lowest;
    }

    void SwitchRoomBackgroundSprite(int x, int y)
    {
        if (roomGrid[x, y] != null)
        {
            var _ref = roomGrid[x, y].GetComponent<BaseRoomData>();
            bool leftHasWall = PointHasRoom(x - 1, y);
            bool rightHasWall = PointHasRoom(x + 1, y);
            if (_ref != null)
            {
                if (leftHasWall && rightHasWall)
                {
                    _ref.backgroundSprite = BaseRoomData.BackgroundSprite.leftDoor_RightDoor;
                }
                else if (leftHasWall && !rightHasWall)
                {
                    _ref.backgroundSprite = BaseRoomData.BackgroundSprite.leftDoor_RightWall;
                }
                else if (!leftHasWall && rightHasWall)
                {
                    _ref.backgroundSprite = BaseRoomData.BackgroundSprite.leftWall_RightDoor;
                }
                else
                {
                    _ref.backgroundSprite = BaseRoomData.BackgroundSprite.leftWall_RightWall;
                }
                _ref.ConstructRoom();
            }
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
