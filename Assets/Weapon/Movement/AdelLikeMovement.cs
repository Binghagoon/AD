using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdelLikeMovement : WeaponMovement
{



    public float maxSpeed = 30f;
    public float accel = 50f;

    private Vector3 vel = Vector3.zero;
    //private Vector3 acc = Vector3.zero;
    
    public override void MoveToTarget(float deltatime, Transform target)
    {
        //Debug.Log("MissileMovement MoveToTarget");

        

        Vector3 dir = (target.position - transform.position).normalized;

        vel += (dir * accel * deltatime);

        vel = vel.normalized * Mathf.Min(vel.magnitude, maxSpeed);

        //transform.Translate((vel * deltatime));
        transform.position += vel * deltatime;
        Quaternion q = Quaternion.LookRotation(vel);
        transform.rotation = q;

    }
}
