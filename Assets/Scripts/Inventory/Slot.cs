using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public string itemName;
    public Text itemCount;
    public Image itemIcon;
    public int _itemCount = 0;

    public void UpdateSlotUI(Item _item, int _count = 1)
    {
        item = _item;
        itemName = item.itemName;
        _itemCount = _count;
        itemIcon.sprite = item.itemImage;
        if (item.itemType != ITEM_TYPE.EQUIPMENT)
        {
            itemCount.gameObject.SetActive(true);
            itemCount.text = _itemCount.ToString();
        }
        else
        {
            itemCount.gameObject.SetActive(false);
            itemCount.text = "0";
        }
        itemIcon.gameObject.SetActive(true);
    }

    public void AddCount(int _count)
    {

        _itemCount += _count;
        itemCount.text = _itemCount.ToString();
    }

    public void RemoveSlot()
    {
        item = null;
        item.itemName = "";
        _itemCount = 0;
        itemIcon.gameObject.SetActive(false);
    }
}
