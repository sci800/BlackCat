using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected int bulletAmount;
    [SerializeField] protected float damge;
    [SerializeField] protected Transform firePos;
    [SerializeField] private int ReloadbulletAmount;

    public bool GetBulletAmount()
    {
        if (bulletAmount > 0)
        {
            bulletAmount--;
            return true;
        }
        else
        {
            Reload();
            return false;
        }
                
    }

    public void SetBulletAmount(int _amount)
    {
        bulletAmount += _amount;
    }

    private void Reload()
    {
        bulletAmount = ReloadbulletAmount;
    }

    public virtual void Shot(Vector3 dir)
    {
        Debug.Log("Error");
    }


    
}
