using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class StoragePoint : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private StorageType.Type storage;
    public StorageType.Type Storage
    {
        get
        {
            return storage;
        }
        set
        {
            storage = value;
            spriteRenderer.sprite = StorageType.GetSprite(value);
            transform.Effect_Jiggle(1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
