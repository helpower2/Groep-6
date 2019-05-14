using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void SaveState(string saveName)
    {
        ISaveable[] gameObjects = Resources.FindObjectsOfTypeAll(typeof(ISaveable)) as ISaveable[];
        
    } 
}
