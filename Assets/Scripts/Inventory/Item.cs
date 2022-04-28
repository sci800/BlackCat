using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_TYPE
{
    EQUIPMENT,
    CONSUMABLES,
    ETC,
    NONE
}

[System.Serializable]
public class Item
{
    public ITEM_TYPE itemType;
    public string itemName;
    public Sprite itemImage;
    public GameObject itemObject;

    public bool Use()
    {
        return false;
    }
}
