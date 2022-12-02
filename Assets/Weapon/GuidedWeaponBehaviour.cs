using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(WeaponMovement))]

public class GuidedWeaponBehaviour : WeaponBehaviour
{
    [SerializeField]
    Transform target;
    bool IsTracing;
    bool isHit = false;
    WeaponMovement movement;
    public override void StartAttack()
    {
        FindTarget();

        IsTracing = true;
    }

    public override void StopAttack()
    {
        IsTracing = false;
    }

    private void FindTarget()
    {
        //TODO:
        // Find Monster

    }

    /// <summary>
    /// Must be Implemented
    /// </summary>
    private void MoveToTarget(float deltatime)
    {
        movement.MoveToTarget(deltatime, target);
    }

    private bool IsHit()
    {
        return isHit;
    }
    /// <summary>
    /// can me changed
    /// </summary>
    private void OnHitTarget()
    {
        FindTarget();
        isHit = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root == target.root)
        {
            //OnHit
            isHit = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<WeaponMovement>();
        Debug.Log(movement);
        StartAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTracing)
        {
            Debug.Log("AA");
            MoveToTarget(Time.deltaTime);
        }

        if (IsHit())
        {
            OnHitTarget();
        }
        
    }
}
