using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    [SerializeField] private GameObject bulletObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shot(Vector3 dir)
    {
        Debug.Log("Gun");
        GameObject _obj = Instantiate(bulletObject, firePos.position, transform.parent.rotation);
        
    }
}
