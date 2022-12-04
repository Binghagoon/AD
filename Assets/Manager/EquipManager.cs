using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 전체 장비 정보
/// </summary>
[System.Serializable]
public struct EquipData{
    public GameObject prefab;
    public Sprite icon;
    public bool isValid;
    public int ID;
}

public class EquipManager : Singleton<EquipManager>
{
    [SerializeField]
    EquipData[] equipDatas;
    // Start is called before the first frame update

    public EquipData[] EquipDatas { get { return equipDatas; } }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
