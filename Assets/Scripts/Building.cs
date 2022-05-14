using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Materials
{
    public string items;
    public int curCount;
    public int count;
}

public class Building : MonoBehaviour
{
    enum STATE
    {
        BEFORE,
        CONSTRUCT,
        AFTER
    }

    public GameObject panel;
    public Slot[] smallSlot;
    public Slot[] bigSlot;
    public int index = 0;
    private bool isActive;
    private BuildingUI buildingUi;
    private void Start()
    {
        smallSlot = GameObject.Find("Player").GetComponent<Inventory>().slotsSmall;
        bigSlot = GameObject.Find("Player").GetComponent<Inventory>().slotsBig;
        buildingUi = panel.GetComponent<BuildingUI>();

    }

   
    public Materials[] materials;

    public void Interaction(EItemType _necessaryItem)
    {
        isActive = !isActive;
        panel.SetActive(isActive);
    }

    public void addItem(int array)
    {
        index = 0;
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
                        int result = smallSlot[index]._itemCount - materials[array].count;
                        if(index < 9)
                        {
                            bigSlot[index].SubCount(result);
                        }
                        smallSlot[index].SubCount(result);
                        materials[array].curCount = materials[array].count;
                    }
                    else
                    {
                        if (index < 9)
                        {
                            bigSlot[index].RemoveSlot();
                        }
                        materials[array].curCount += smallSlot[index]._itemCount;
                        smallSlot[index].RemoveSlot();
                    }
                    break;
                }
            }
            index++;

        }

        buildingUi.UpdateUI();

    }
}
