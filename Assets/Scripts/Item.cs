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

public enum ITEM_KINDS
{
    ANIMAL,
    PLANT,
    ROCK,
    NONE
}

[System.Serializable]
public class Item
{
    public ITEM_TYPE itemType;
    public ITEM_KINDS itemkind;
    public string itemName;
    public Sprite itemImage;
    //public GameObject itemObject;



    public bool Use()
    {
        return false;
    }
}
