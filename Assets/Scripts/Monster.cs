using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    float speed;
    Transform player;
    MonsterManager manager;
    //Player setter
    bool isValide;
    public Transform Player { set { player = value; } }
    public MonsterManager MonsterManager { set { manager = value; } }
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
        Debug.Log(string.Format("AD| HP| before : {0} ", hp));
        hp -= damage;
        Debug.Log(string.Format("AD| HP| after : {0}", hp));

        if (hp < 0)
        {
            //anim.SetInteger("Walk", 0);
            //anim.SetTrigger("Die");
            Debug.Log(manager);
            if (manager!= null) manager.removeMonster(this);
            Destroy(gameObject);

            Debug.Log(this);
            Debug.Log(string.Format("AD| Destroyed"));

            isValide = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null ) transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
