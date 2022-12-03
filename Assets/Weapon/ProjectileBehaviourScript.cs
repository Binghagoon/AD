using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProjectileBehaviourScript : WeaponBehaviour
{
    protected Monster target;
    protected bool IsLaunched;
    public override void StartAttack()
    {
        FindTarget();

        IsLaunched = true;
    }

    public override void StopAttack()
    {
        IsLaunched = false;
    }

    protected void FindTarget()
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
    /// can me changed
    /// </summary>
    protected virtual void OnHitTarget()
    {
        Debug.Log("OnHitTarget");
        //target.OnDamage(Attack); //todo
        Destroy(target.gameObject); //TMP
        Debug.Log("OnHitTarget2");

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
            OnHitTarget();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
