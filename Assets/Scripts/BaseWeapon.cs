using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public enum Type
    {
        WEAPON,
        TOOL
    }
    [SerializeField] protected float damage;
    public float attackDelay;
    [HideInInspector] public float lastAttackTime;
    public Type type;
    [Header("Weapon")]
    [SerializeField] protected int bulletAmount;
    [SerializeField] protected float speed;
    [SerializeField] protected Transform firePos;
    [SerializeField] private int ReloadbulletAmount;
    protected bool isAttack;

    #region weapon
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


    public bool GetAttack()
    {
        return isAttack;
    }

    public void SetBulletAmount(int _amount)
    {
        bulletAmount += _amount;
    }

    private void Reload()
    {
        bulletAmount = ReloadbulletAmount;
    }
    #endregion

    public virtual void Attack()
    {
        lastAttackTime = Time.time;
        
    }


    
}
