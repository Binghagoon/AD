using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    Transform player; //TODO: 동적으로 가져오기

    // Start is called before the first frame update
    void Start()
    {
        SpawnWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
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
