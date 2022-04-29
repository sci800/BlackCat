using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shot(Vector3 dir)
    {
        Debug.Log("Bow");
    }
}
