using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private float speed;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    public void SetBullet(float _damage, float _speed)
    {
        damage = _damage;
        speed = _speed;
    }

}
