﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageType : MonoBehaviour
{
    static SpriteReferences spriteReferences;
    public enum Type
    {
        Weed, //0
        Empty //1
    }

    private void Start()
    {
        spriteReferences = GameObject.FindObjectOfType<SpriteReferences>();
    }

    public static Sprite GetSprite(Type type)
    {
        switch (type)
        {
            case Type.Weed:
                return spriteReferences.Weed;
            case Type.Empty:
                return null;
            default:
                return null;
        }
    }
}
