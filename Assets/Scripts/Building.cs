using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : MonoBehaviour
{
    enum STATE
    {
        BEFORE,
        CONSTRUCT,
        AFTER
    }

    public Slot[] smallSlot;
    public Slot[] bigSlot;
    public int index = 0;
    private void Start()
    {
        smallSlot = GameObject.Find("Player").GetComponent<Inventory>().slotsSmall;
        bigSlot = GameObject.Find("Player").GetComponent<Inventory>().slotsBig;
    }

    [System.Serializable]
    public struct Materials
    {
        public string items;
        public int curCount;
        public int count;
    }
    public Materials[] materials;

    public void addItem(int array)
    {
        //string[] itemname = _itemName.Split(":");
        //int array = int.Parse(itemname[0]);
       
        while (smallSlot[index].itemName != "")
        {
            if (smallSlot[index].itemName == materials[array].items)
            {
                if (materials[array].curCount < materials[array].count)
                {
                    if (smallSlot[index]._itemCount > materials[array].count - materials[array].curCount)
                    {
                        Debug.Log(smallSlot[index]._itemCount - materials[array].count);
                        smallSlot[index].SubCount(smallSlot[index]._itemCount - materials[array].count);
                        materials[array].curCount = materials[array].count;
                    }
                    else
                    {
                        materials[array].curCount += smallSlot[index]._itemCount;
                        smallSlot[index].RemoveSlot();
                    }
                    break;
                }
            }
            index++;

        }

    }
}
