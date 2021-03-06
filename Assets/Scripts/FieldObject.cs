using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Drop_Item
{
    public Item dropItem;
    public int persent;
    public EItemType needNecessaryItem;
}
    

public class FieldObject : MonoBehaviour
{
    public enum TYPE
    {
        ALIVE,
        BUILDING
    }
    public TYPE type;
    public bool rockObject;

    public int interaction_Count;
    public int hit_Count;
    public float interaction_persent;
    public AudioSource hitSound;

    public Drop_Item[] interraction_dropItems;
    public Drop_Item[] dead_dropItems;

    public Transform dropPos;

    public GameObject filed_item;

    public GameObject plant_object;
    public GameObject rock_object;
    public GameObject animal_object;
    public GameObject weapon_object;

    private int interaction_total = 0;
    private int dead_total = 0;
    private int[] persent_array = { 70, 25, 5 };
    private void Start()
    {
        for (int i = 0; i < interraction_dropItems.Length; i++)
        {
            interaction_total += interraction_dropItems[i].persent;
        }
        for (int i = 0; i < dead_dropItems.Length; i++)
        {
            dead_total += dead_dropItems[i].persent;
        }

    }

    public void Interaction(EItemType _necessaryItem)
    {
        if (interaction_Count <= 0 || type != TYPE.BUILDING) return;

        interaction_Count--;
        DropItme(true, _necessaryItem);

    }

    //parameters[0] : Damage
    //parameters[1] : EItemTpye
    public void OnDamage(int _damage, EItemType _needNecessaryItem)
    {
        if(hitSound.isPlaying)
        {
            hitSound.Stop();
        }
        hitSound.Play();

        if (rockObject == false)
        {
            hit_Count -= _damage;
            if (hit_Count <= 0)
            {            
                DropItme(false,_needNecessaryItem);
                gameObject.SetActive(false);
            }
        }
        else
        {
            hit_Count--;
            DropItme(false, _needNecessaryItem);
            if (hit_Count <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void onDead()
    {
        DropItme(false);
        Destroy(gameObject);
    }

    private void DropItme(bool _isinteraction, EItemType _needNecessaryItem = EItemType.NONE)
    {
        if (_isinteraction == true)
        {
            if (!(Random.Range(0, 101) <= interaction_persent)) return;

            int dropindex = RandomItem(interraction_dropItems, true, _needNecessaryItem);
            if (dropindex >= 0)
            {
                GameObject obj = Instantiate(filed_item, dropPos.position, Quaternion.identity);
                GameObject kind_obj = Instantiate(Kinds_Object(dropindex, interraction_dropItems), obj.transform);

                kind_obj.transform.localPosition = Vector3.zero;
                obj.GetComponent<FieldItems>().SetItem(interraction_dropItems[dropindex].dropItem);
                obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3f, 3f), 3.5f, Random.Range(-3f, 3f)), ForceMode.Impulse);

            }
        }
        else
        {
            StartCoroutine(Instantiate_delay(_needNecessaryItem));
            
        }
    }

    private GameObject Kinds_Object(int _dropIndex, Drop_Item[] dropitems)
    {
        if (dropitems[_dropIndex].dropItem.itemType == ITEM_TYPE.EQUIPMENT)
        {
            return weapon_object;
        }
        else
        {
            switch (dropitems[_dropIndex].dropItem.itemkind)
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

    private int RandomCount()
    {
        int persent = 0;
        int selectNum = 0;

        int total = 0;
        for (int i = 0; i < persent_array.Length; i++)
        {
            total += persent_array[i];
        }

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 1; i <= persent_array.Length; i++)
        {
            persent += persent_array[i - 1];
            if (selectNum <= persent)
            {
                return i;
            }
        }
        return -1;
    }

    private int RandomItem(Drop_Item[] drop_Items, bool _isinteraction, EItemType _necessaryItem = EItemType.NONE)
    {
        int persent = 0;
        int selectNum = 0;
        selectNum = Mathf.RoundToInt((_isinteraction ? interaction_total : dead_total) * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < drop_Items.Length; i++)
        {
            persent += drop_Items[i].persent;
            if (_necessaryItem == drop_Items[i].needNecessaryItem || drop_Items[i].needNecessaryItem == EItemType.NONE)
            {             
                if (selectNum <= persent)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    IEnumerator Instantiate_delay(EItemType _necessaryItem)
    {
        int dropindex = RandomItem(dead_dropItems, false, _necessaryItem);
        Debug.Log(dropindex);
        if (dropindex >= 0)
        {
            for (int i = 0; i < RandomCount(); i++)
            {
                GameObject obj = Instantiate(filed_item, dropPos.position, Quaternion.identity);
                GameObject kind_obj = Instantiate(Kinds_Object(dropindex, dead_dropItems), obj.transform);

                kind_obj.transform.localPosition = Vector3.zero;
                obj.GetComponent<FieldItems>().SetItem(dead_dropItems[dropindex].dropItem);
                obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3f, 3f), 2.5f, Random.Range(-3f, 3f)), ForceMode.Impulse);
                Debug.Log("in");
                yield return new WaitForSeconds(0.5f);
            }
        }
        
    }
}

