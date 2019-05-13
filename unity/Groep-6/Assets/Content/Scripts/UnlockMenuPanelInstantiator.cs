﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockMenuPanelInstantiator : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public int childCount
    {
        get
        {
            return transform.childCount;
        }
    }
    public void InstantiatePrefab(Texture2D _texture, string _name, int _price)
    {
        var prefabTransform = GameObject.Instantiate(prefab.transform, transform);
        prefabTransform.GetChild(0).GetComponent<RawImage>().texture = _texture;
        prefabTransform.GetChild(1).GetComponent<Text>().text = _name;
        prefabTransform.GetChild(2).GetComponent<Text>().text = _price.ToString() + "G";
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            InstantiatePrefab(Texture2D.blackTexture, "Sample", 750);
        }
    }
}
