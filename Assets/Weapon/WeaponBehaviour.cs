using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    [SerializeField]
    protected int Attack = 10;
    // Start is called before the first frame update

    public abstract void StartAttack();
    public abstract void StopAttack();

    public void SetAttack(int attack)
    {
        Attack = attack;
    }

    protected void DamageToMonster(Monster m,int _Attack)
    {
        //Destroy(m.gameObject);//TODO:
        m.OnDamage(_Attack);
    }
}
