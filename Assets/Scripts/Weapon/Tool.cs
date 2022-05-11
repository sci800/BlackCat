using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : BaseWeapon
{

    [SerializeField] private BoxCollider hitBox;

    public override void Attack()
    {
        base.Attack();
        StartCoroutine(Swing());
        

    }

    IEnumerator Swing()
    {
        hitBox.gameObject.GetComponent<MeleeAtk>().SetMelee(damage);
        isAttack = true;
        yield return new WaitForSeconds(0.1f);
        hitBox.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hitBox.enabled = false;
        isAttack = false;
    }

    

 
}
