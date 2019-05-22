using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T _instance { get; private set; }

    public static T Instance()
    {
        _instance = FindObjectOfType<T>();
        return _instance;
    }
}