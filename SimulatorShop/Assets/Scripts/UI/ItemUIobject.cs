using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default, Food, Weapon, Instrãment}

public class ItemUIobject : ScriptableObject
{
    public string itemName;
    public int maxAmount;
    public GameObject itemPrefab;
    public ItemType itemType;
    public string itemInscreption;
}
