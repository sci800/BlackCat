using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

    public GameObject fieldItemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Item item = itemDB[Random.Range(0, 3)];
            GameObject obj = Instantiate(item.itemObject, pos[i], Quaternion.identity);
            obj.GetComponent<FieldItems>().SetItem(item);
        }
        
    }
}
