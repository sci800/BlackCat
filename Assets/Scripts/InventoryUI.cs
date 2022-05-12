using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] inventoryPanel;

    bool activeInventory = false;


    private void Start()
    {
        inventoryPanel[0].SetActive(activeInventory);
        inventoryPanel[1].SetActive(!activeInventory);
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel[0].SetActive(activeInventory);
            inventoryPanel[1].SetActive(!activeInventory);
        }
    }

 

}
