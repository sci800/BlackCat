using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private int slotCnt;

    public List<Item> items = new List<Item>();

    public Slot[] slotsBig;
    public Slot[] slotsSmall;

    public Transform[] slotHolder;


    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
        }
    }

    void Start()
    {
        SlotCnt = 32;
        slotsBig = slotHolder[1].GetComponentsInChildren<Slot>();
        slotsSmall = slotHolder[0].GetComponentsInChildren<Slot>();
    }

   
    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {        
            if (_item.itemType != ITEM_TYPE.EQUIPMENT)
            {
                for(int i = 0; i < slotsSmall.Length; i++)
                {
                    if (slotsSmall[i].item.itemName == _item.itemName)
                    {
                        slotsSmall[i].AddCount(1);

                        if(i < 9)
                        {
                            slotsBig[i].AddCount(1);
                        }

                        return true;
                    }                        
                }
            }

            for(int i = 0; i < slotsSmall.Length; i++)
            {
                if(slotsSmall[i].item.itemName == "")
                {
                    slotsSmall[i].UpdateSlotUI(_item);
                    if (i < 9)
                    {
                        slotsBig[i].UpdateSlotUI(_item);
                    }
                    return true;
                }
            }         
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.gameObject.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
            {
                fieldItems.DestroyItem();
            }
        }
    }

    
}
