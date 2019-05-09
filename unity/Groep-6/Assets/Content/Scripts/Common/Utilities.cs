using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public static class Utilities
{
    public enum mode
    {
        SongButton,
        SettingsButton,
        SongListButton,
        SongLabelEditButton
    }

    public enum axis
    {
        x,
        y
    }

    /// <summary> Returnt een GameObject met naam.
    /// <para> Als het GameObject niet gevonden is, wordt een error log gegooid. </para>
    /// </summary>
    public static GameObject FindGameObjectOrError(string objectName)
    {
        GameObject foundGameObject = GameObject.Find(objectName);
        if (foundGameObject == null)
        {
            Debug.LogError("Make sure " + objectName + " is present");
        }
        return foundGameObject;
    }

    /// <summary> Voegt een ClickListener op een button.
    /// <para> Callt <see cref= "FindGameObjectOrError"/> om te checken of die button bestaat  </para>
    /// </summary>
    public static GameObject FindButtonAndAddOnClickListener(string buttonName, UnityAction listenerAction )
    {
        GameObject button = FindGameObjectOrError(buttonName);
        button.GetComponent<Button>().onClick.AddListener(listenerAction);
        return button;
    }

    /// <summary>
    /// Returns an AudioType of the type corresponding to the given extension string
    /// </summary>
    /// <param name="extension">extension (including the ".")</param>
    /// <returns></returns>
    public static AudioType GetAudioTypeByExtension(string extension)
    {
        switch (extension)
        {
            case ".wav": return AudioType.WAV;

            case ".ogg": return AudioType.OGGVORBIS;

            case ".aiff": return AudioType.AIFF;

            case ".mpeg": return AudioType.MPEG;

            default: return AudioType.WAV;
        }
    }
    /// <summary>
    /// Gets a timeSpan from a song to format
    /// </summary>
    /// <param name="_timeSpan"></param>
    /// <returns></returns>
    public static string GetDurationStringFromTimeSpan(System.TimeSpan _timeSpan)
    {
        string temp = "";
        temp += _timeSpan.Hours > 0 ? _timeSpan.Hours + ":" : "";
        temp += _timeSpan.Hours > 0 ? _timeSpan.Minutes > 0 ? _timeSpan.Minutes > 9 ? _timeSpan.Minutes + ":" : "0" + _timeSpan.Minutes + ":" : "00:" : _timeSpan.Minutes + ":";
        temp += _timeSpan.Minutes > 0 ? _timeSpan.Seconds > 0 ? _timeSpan.Seconds > 9 ? _timeSpan.Seconds.ToString() : "0" + _timeSpan.Seconds : "00" : _timeSpan.Seconds.ToString();
        return temp;
    }

    internal static void DestroyAllGameObjectsWithTag(string _tag)
    {
        var objects = GameObject.FindGameObjectsWithTag(_tag);
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject.Destroy(objects[i]);
        }
    }
    /// <summary>
    /// Returns a Vector2 with an axis of the specified value
    /// </summary>
    /// <param name="_vector2">Vector to be changed</param>
    /// <param name="_value">Value of axis</param>
    /// <param name="_axis">selected axis</param>
    /// <returns></returns>
    public static Vector2 SetVector2Axis(Vector2 _vector2, float _value, axis _axis)
    {
        Vector2 returnData;
        if (_axis == axis.x)
        {
            returnData = new Vector2(_value, _vector2.y);
        }
        else
        {
            returnData = new Vector2(_vector2.x, _value);
        }
        return returnData;
    } 
}
