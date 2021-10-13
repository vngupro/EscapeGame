using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [Button]
    public void InitSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.sprite;
    }
}
