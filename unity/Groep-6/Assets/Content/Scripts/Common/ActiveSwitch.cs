using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSwitch : MonoBehaviour
{
    public void Switch(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
