using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomHandler : MonoBehaviour
{
    GameObject[,] GameObjectGrid;

    private void Start()
    {
        List<GameObject> Rooms = GameObject.FindGameObjectsWithTag("Room").ToList();

        Vector2Int highest = new Vector2Int(0, 0);
        Vector2Int lowest = new Vector2Int(99, 99);
        
        foreach (var room in Rooms)
        {
            var pos = room.GetComponent<Transform>().position;
            var x = Mathf.RoundToInt (pos.x);
            var y = Mathf.RoundToInt (pos.y * -1);
            highest.x = x > highest.x ? x : highest.x;
            highest.y = y > highest.y ? y : highest.y;
            lowest.x = x < lowest.x ? x : lowest.x;
            lowest.y = y < lowest.y ? y : lowest.y;
        }
        var size = highest - lowest + new Vector2Int(1,1);
        GameObjectGrid = new GameObject[size.x, size.y];
        Debug.Log(size);
        foreach (var room in Rooms)
        {
            var pos = room.GetComponent<Transform>().position;
            Vector2Int worldPos = new Vector2Int();
            worldPos.x = Mathf.RoundToInt(pos.x);
            worldPos.y = Mathf.RoundToInt(pos.y * -1);
            var posInGrid = convertWorldSpaceToGridSpace(lowest, worldPos);
            GameObjectGrid[posInGrid.x, posInGrid.y] = room;
        }
        Debug.Log(GameObjectGrid[1, 1].gameObject.name);
    }

    Vector2Int convertWorldSpaceToGridSpace(Vector2Int lowest, Vector2Int worldSpace)
    {
        return worldSpace - lowest;
    }

}
