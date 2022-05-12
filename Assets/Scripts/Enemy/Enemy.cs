using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseStatus
{
    public enum STATE
    {
        WALK,
        RUNAWAY,
        FOLLOW,
        SEARCH,
        DEAD,
        NONE
    }
    public float followDistance;
    public float SearchDistance;
    public float RunAwayDistance;
    public GameObject target;
    private Vector3 dir;
    private FieldObject fieldObject;
    private void Start()
    {
        fieldObject = GetComponent<FieldObject>();
    }

    private void Search()
    { 

    }
    private void Walk()
    {

    }
    private void Follow()
    {

    }
    private void RunAway()
    {

    }

    private void Dead()
    {
        fieldObject.onDead();
    }


}
