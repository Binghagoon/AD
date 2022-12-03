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
    bool isValide;
    public Transform Player { set { player = value; } }
    public MonsterManager MonsterManager { set { MonsterManager = value; } }
    public bool IsValide { get { return isValide; } }
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Walk", 1);
        isValide = true;
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            anim.SetInteger("Walk", 0);
            //anim.SetTrigger("Die");
            manager.removeMonster(this);
            Destroy(gameObject, 2f);
            isValide = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
