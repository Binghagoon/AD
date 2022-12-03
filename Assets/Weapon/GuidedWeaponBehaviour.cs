using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(WeaponMovement))]

public class GuidedWeaponBehaviour : WeaponBehaviour
{
    [SerializeField]
    int AttackCount = 1;

    Monster target;
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
        Monster[] tgs = FindObjectsOfType<Monster>();
        foreach (Monster t in tgs)
        {
            if (t.IsValide)
            {
                target = t;
                break;
            }
        }
        
        Debug.Log(target);
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

    private bool IsHit()
    {
        return isHit;
    }
    /// <summary>
    /// can me changed
    /// </summary>
    private void OnHitTarget()
    {
        Debug.Log("OnHitTarget");
        //target.OnDamage(Attack); //todo
        Destroy(target.gameObject); //TMP
        Debug.Log("OnHitTarget2");
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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.transform.root == target.transform.root)
        {
            //OnHit
            //isHit = true;
            OnHitTarget();
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
        if (!target.IsValide)
        {
            target = null;
        }

        if(target == null)
        {
            FindTarget();
        }

        if (IsTracing)
        {
            //Debug.Log("AA");
            MoveToTarget(Time.deltaTime);
        }

        
    }
}
