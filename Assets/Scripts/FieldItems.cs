using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public TMP_Text item_name;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        item_name.text = item.itemName;
        //item.itemObject = _item.itemObject;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }
}
