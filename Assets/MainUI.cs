using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    GameObject EquipDataButtonPrefab;
    [SerializeField]
    Transform EquipScrollbarContents;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEquipDataButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipClicked()
    {
        Debug.Log("OnEquipClicked");
    }

    public void OnDungeonClicked()
    {
        Debug.Log("OnDungeonClicked");
    }

    public void OnEquipDataButtonClicked(int ID)
    {

        Debug.Log(string.Format("OnEquipDataButtonClicked : {0}", ID));
    }

    public void SpawnEquipDataButton()
    {
        foreach (EquipData e in EquipManager.Instance.EquipDatas)
        {
            EquipDataButton edb = Instantiate(EquipDataButtonPrefab, EquipScrollbarContents).GetComponent<EquipDataButton>();

            edb.Init(this,e);

        }
    }


}
