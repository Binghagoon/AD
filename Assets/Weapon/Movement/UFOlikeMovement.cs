using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOlikeMovement : WeaponMovement
{

    public float Speed = 10f;

    public override void MoveToTarget(float deltatime, Transform target)
    {
        Debug.Log("MissileMovement MoveToTarget");

        
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate((dir * Speed * deltatime));

    }
}
