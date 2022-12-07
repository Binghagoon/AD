using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(WeaponMovement))]

public class GuidedWeaponBehaviour : ProjectileBehaviourScript
{
    [SerializeField]
    int AttackCount = 1;
    [SerializeField]
    float LifeTime = 10;

    bool isHit = false;
    WeaponMovement movement;

    public override void StartAttack()
    {
        base.StartAttack();

        SetTarget(target);

        Destroy(gameObject, LifeTime); //SetLifeTimeTimer
    }


    /// <summary>
    /// Must be Implemented
    /// </summary>
    private void MoveToTarget(float deltatime)
    {
        if(target != null)
        {
            movement.MoveToTarget(deltatime, target.transform);
        }
        
    }

    private void SetTarget(Monster target)
    {
        movement.SetTarget(target.transform);
    }

    private bool IsHit()
    {
        return isHit;
    }

    protected override void OnHitTarget()
    {
        base.OnHitTarget();
        AttackCount--;
        if (AttackCount == 0)
        {

            Destroy(gameObject);
        }
        else
        {

            target = null;

            isHit = false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<WeaponMovement>();
        //Debug.Log(movement);
        StartAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null&& !target.IsValide)
        {
            target = null;
        }

        if(target == null)
        {
            FindTarget();
        }

        if (IsLaunched)
        {
            //Debug.Log("AA");
            MoveToTarget(Time.deltaTime);
        }

        
    }
}
