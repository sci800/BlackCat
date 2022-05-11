using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtk : MonoBehaviour
{
    [SerializeField] private float damage;

    public void SetMelee(float _damage)
    {
        damage = _damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building") || other.CompareTag("alive"))
        {
            other.GetComponent<FieldObject>().SendMessage("OnDamage", damage);
        }
    }
}
