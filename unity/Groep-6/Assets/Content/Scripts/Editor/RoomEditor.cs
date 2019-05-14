using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(IRoom))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IRoom myScript = (IRoom)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.ConstructRoom();
        }
    }
}