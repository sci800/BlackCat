using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtk : MonoBehaviour
{
    [SerializeField] private float damage;
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void SetMelee(float _damage)
    {
        damage = _damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building") || other.CompareTag("alive"))
        {
 
            other.GetComponent<FieldObject>().OnDamage((int)damage, player.necessaryItem);
        }
    }
}
