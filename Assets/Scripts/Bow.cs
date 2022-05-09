using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    [SerializeField] private GameObject bowObject;

    public override void Shot()
    {
        Debug.Log("Bow");
        GameObject _obj = Instantiate(bowObject, firePos.position, transform.parent.rotation);
        _obj.GetComponent<Bullet>().SetBullet(damage, speed);
    }
}
