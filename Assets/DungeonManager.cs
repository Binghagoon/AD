using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    Transform player; //TODO: 동적으로 가져오기

    [SerializeField]
    float EndTime = 300;

    float timer;

    public float RemainTime { get { return EndTime - timer; } }

    void OnGameEnd()
    {
        SceneManager.LoadScene("ArMain");
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapon();

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= EndTime)
        {
            OnGameEnd();
        }
    }

    void SpawnWeapon()
    {
        List<EquipData> eqs = EquipManager.Instance.GetWearingEquipDatas();

        foreach(EquipData e in eqs)
        {
            Instantiate(e.prefab, player);
        }
        
    }
}
