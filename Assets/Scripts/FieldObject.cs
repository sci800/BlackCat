using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Drop_Item
{
    public Item dropItem;
    public int persent;
}

public class FieldObject : MonoBehaviour
{
    public int interaction_Count;
    public int hit_Count;
    public int total = 0;

    public float interaction_persent;

    public Drop_Item[] dropItems;
    public Transform dropPos;

    public GameObject filed_item;
    public GameObject plant_object;
    public GameObject rock_object;
    public GameObject animal_object;
    public GameObject weapon_object;

    private void Start()
    {
        for(int i = 0; i < dropItems.Length; i++)
        {
            total += dropItems[i].persent;
        }

   
    }

    public void Interaction()
    {
        if (interaction_Count <= 0) return;

        interaction_Count--;
        DropItme();
        
    }

    private void DropItme()
    {
        if (!(Random.Range(0, 101) <= interaction_persent)) return;

        int dropindex = RandomItem();
        if (dropindex >= 0)
        {
            GameObject obj = Instantiate(filed_item, dropPos.position, Quaternion.identity);
            GameObject kind_obj = Instantiate(Kinds_Object(dropindex),obj.transform);

            kind_obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<FieldItems>().SetItem(dropItems[dropindex].dropItem);
        }
    }

    private GameObject Kinds_Object(int _dropIndex)
    {
        if (dropItems[_dropIndex].dropItem.itemType == ITEM_TYPE.EQUIPMENT)
        {
            return weapon_object;
        }
        else
        {
            switch (dropItems[_dropIndex].dropItem.itemkind)
            {
                case ITEM_KINDS.ANIMAL:
                    return animal_object;
                case ITEM_KINDS.PLANT:
                    return plant_object;
                case ITEM_KINDS.ROCK:
                    return rock_object;
            }
        }

        return null;
    }

    private int RandomItem()
    {
        int persent = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for(int i = 0; i < dropItems.Length; i++ )
        {
            persent += dropItems[i].persent;
            if(selectNum <= persent)
            {
                return i;
            }         
        }
        return -1;
    }

}
