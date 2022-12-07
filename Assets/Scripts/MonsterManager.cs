using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public bool spawnerActive = false;
    [SerializeField]
    GameObject player;
    List<Monster> monsters = new List<Monster>();
    [SerializeField]
    GameObject[] monsterPrefab;
    [SerializeField]
    float spawnTime = 0.5f;
    [SerializeField]
    float size = 0.1f;
    float timer = 0;

    List<(Vector3, Vector3)> squares = new List<(Vector3, Vector3)>();
    public void removeMonster(Monster monsterScript)
    {
        monsters.Remove(monsterScript);
    }

    // 죽지 않은 몬스터를 반환하는 함수
    public List<Monster> getMonsters()
    {
        return new List<Monster>(monsters);
    }

    // a, b are vetices of the square
    public void addSquare(Vector3 a, Vector3 b)
    {
        squares.Add((a, b));
    }

    // a, b are vetices of the square
    public void removeSquare(Vector3 a, Vector3 b)
    {
        squares.Remove((a, b));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (squares.Capacity == 0)
        {
            addSquare(new(-5, 0, -5), new(5, 0, 5));
        }
    }
    Vector3 RandomPositionInSquare(Vector3 a, Vector3 b)
    {
        float x = Random.Range(a.x, b.x);
        float z = Random.Range(a.z, b.z);

        return new Vector3(x, 0, z);
    }
    GameObject SpawnMonsterInSquare(Vector3 a, Vector3 b)
    {
        int monsterIndex = Random.Range(0, monsterPrefab.Length);
        GameObject monster = Instantiate(monsterPrefab[monsterIndex]);
        monster.transform.localScale *= size;       //Shrinking size for VR
        monster.transform.position = RandomPositionInSquare(a, b);
        Monster monsterScript = monster.GetComponent<Monster>();
        monsterScript.Player = player.transform;
        monsterScript.MonsterManager = this;
        monster.transform.parent = transform;
        monsters.Add(monsterScript);
        return monster;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            timer -= spawnTime;
            if(spawnerActive)
            {
                (Vector3, Vector3) square = squares[Random.Range(0, squares.Count)];
                Debug.Log("Spawn a monster from " + square);
                SpawnMonsterInSquare(square.Item1, square.Item2);
            }
        }
    }
}
