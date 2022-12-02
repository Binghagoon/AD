using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    float speed;
    MonsterManager manager;
    Transform player;
    //Player setter
    public Transform Player { set { player = value; } }
    public MonsterManager MonsterManager { set { MonsterManager = value; } }
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Walk", 1);
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            anim.SetInteger("Walk", 0);
            anim.SetTrigger("Die");
            manager.removeMonster(this);
            Destroy(gameObject, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
