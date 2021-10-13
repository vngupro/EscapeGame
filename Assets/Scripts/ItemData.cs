using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [TextArea(3, 3)]
    public string description;
    public Sprite sprite;
    public Sprite spriteSlot;
    public Sprite spriteUI;
}
