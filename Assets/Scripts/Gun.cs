using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    [SerializeField] private GameObject bulletObject;

    public override void Shot()
    {
        Debug.Log("Gun");
        GameObject _obj = Instantiate(bulletObject, firePos.position, transform.parent.rotation);
        _obj.GetComponent<Bullet>().SetBullet(damage, speed);
    }
}
