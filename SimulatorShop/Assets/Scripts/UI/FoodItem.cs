using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/New Food Item")]

public class FoodItem : ItemUIobject
{
    public float healAmount;

    void Start()
    {
        itemType = ItemType.Food;
    }
}
