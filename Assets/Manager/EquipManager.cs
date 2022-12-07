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
    public string name;
    public string info;
    public bool isValid;
    public int ID;

    public static EquipData nodata 
    {
        get
        {
            EquipData tmp;
            tmp.ID = -1;
            tmp.info = "";
            tmp.name = "nodata";
            tmp.icon = null;
            tmp.prefab = null;
            tmp.isValid = false;

            return tmp;
        }
    }
}

public class EquipManager : Singleton<EquipManager>
{
    [SerializeField]
    EquipData[] equipDatas;
    // Start is called before the first frame update
    [SerializeField]
    int MaxEquipCount;


    SortedSet<int> wearing = new SortedSet<int>();

    public EquipData[] EquipDatas { get { return equipDatas; } }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EquipData GetEquipDataById(int ID)
    {
        // TODO: faster

        foreach(EquipData e in EquipDatas)
        {
            if (e.ID == ID)
            {
                return e;
            }
        }

        return EquipData.nodata;
    }

    public bool PutOn(int ID)
    {
        if (wearing.Count < MaxEquipCount)
        {
            wearing.Add(ID);
            return true;
        }
        return false;
    }

    public bool PutOff(int ID)
    {
        wearing.Remove(ID);
        return true;
    }

    public bool IsWaering(int ID)
    {
        return wearing.Contains(ID);
    }

    public List<EquipData> GetWearingEquipDatas()
    {
        List<EquipData> l = new List<EquipData>();

        foreach (EquipData e in EquipDatas)
        {
            if (IsWaering(e.ID))
            {
                l.Add(e);
            }
        }

        return l;
    }
}
