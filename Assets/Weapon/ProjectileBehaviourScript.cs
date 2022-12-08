using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProjectileBehaviourScript : WeaponBehaviour
{
    protected Monster target;
    protected bool IsLaunched;
    protected MonsterManager monsterManager;

    public override void StartAttack()
    {
        FindTarget();

        IsLaunched = true;
        monsterManager = FindObjectOfType<MonsterManager>();
    }

    public override void StopAttack()
    {
        IsLaunched = false;
    }

    protected void FindTarget()
    {
        //TODO:
        // Find Monster
        IEnumerable<Monster> tgs;
        if (monsterManager == null)
        {
            Debug.Log("AD| Find Monster By Engine");
            tgs = FindObjectsOfType<Monster>();
        }
        else
        {
            Debug.Log("AD| Find Monster By MonsterManager");
            tgs = monsterManager.getMonsters();
        }
            
        foreach (Monster t in tgs)
        {
            if (t.IsValide)
            {
                target = t;
                break;
            }
        }

        //Debug.Log(target);
    }

    /// <summary>
    /// can me changed
    /// </summary>
    protected virtual void OnHitTarget()
    {
        Debug.Log("AD| OnHitTarget");

        DamageToMonster(target, Attack);
        Debug.Log("AD| OnHitTarget2");

    }

    protected virtual bool CheckIsHit(Collider other)
    {
        return other.transform.root == target.transform.root;
    }


    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (CheckIsHit(other))
        {
            //OnHit
            //isHit = true;
            if (target.IsValide)
            {
                OnHitTarget();
            }
            
        }
    }
}
