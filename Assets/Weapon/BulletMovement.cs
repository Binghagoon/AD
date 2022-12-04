using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : WeaponMovement
{
    [SerializeField]
    float Speed = 10;
    
    Vector3 vel = Vector3.zero;

    public override void SetTarget(Transform target)
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = (target.position - transform.position).normalized;

        vel = dir * Speed;
    }

    public override void MoveToTarget(float deltatime, Transform target)
    {
        transform.position += (vel * deltatime);
    }
}
