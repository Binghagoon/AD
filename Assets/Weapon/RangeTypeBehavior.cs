using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum AttackType
{
}


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(WeaponMovement))]

public class RangeTypeBehavior : WeaponBehaviour
{
    WeaponMovement movement;
    int attackCount;
    [SerializeField]
    float[] AttackDelayCycle = { 2.0f };

    int nextDelay = 0;
    float AttackDelay;

    float timer = 0;

    bool isAttacking;

    bool isAttacked = false;

    [SerializeField]
    GameObject CollisionEffect = null;

    private float GetNextDelay()
    {
        nextDelay %= AttackDelayCycle.Length;
        return AttackDelayCycle[nextDelay++];
    }

    public override void StartAttack()
    {
        movement.SetTarget(null);

        isAttacking = true;
    }

    public override void StopAttack()
    {
        isAttacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<WeaponMovement>();

        timer = 0;
        AttackDelay = GetNextDelay();
        StartAttack();
    }

    // Update is called once per frame
    void Update()
    {
        movement.MoveToTarget(Time.deltaTime,null);

        timer += Time.deltaTime;

        while (timer >= AttackDelay)
        {
            timer -= AttackDelay;
            AttackDelay = GetNextDelay();
            Debug.Log("BEfore Attack");
            AttackInRange();
        }
    }

    void AttackInRange()
    {
        foreach(Monster m in OnRangeMonsters)
        {
            DamageToMonster(m,Attack);
            if (CollisionEffect != null)
            {
                Instantiate(CollisionEffect, transform.position, transform.rotation);
            }
        }
    }

    HashSet<Monster> OnRangeMonsters = new HashSet<Monster>();

    private void OnTriggerEnter(Collider other)
    {
        Monster m = other.GetComponent<Monster>();

        if(m != null)
        {
            OnRangeMonsters.Add(m);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Monster m = other.GetComponent<Monster>();

        if (m != null)
        {
            OnRangeMonsters.Remove(m);
        }
    }


}
