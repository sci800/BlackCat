using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public TMP_Text[] count;
    public Building building;
    public Transform textHolder;
    private void Start()
    {
        UpdateUI();
        count = textHolder.GetComponentsInChildren<TMP_Text>();
    }

    public void UpdateUI()
    {
        for(int i = 0; i < building.materials.Length; i++)
        {
            count[i].text = string.Format("{0} / {1}", building.materials[i].curCount, building.materials[i].count);
        }
    }

}
