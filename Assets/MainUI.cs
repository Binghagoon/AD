using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    GameObject EquipDataButtonPrefab;
    [SerializeField]
    Transform EquipScrollbarContents;

    [SerializeField]
    Image InfoIcon;
    [SerializeField]
    TextMeshProUGUI InfoText;
    [SerializeField]
    TextMeshProUGUI InfoNameNext;

    [SerializeField]
    Button PutOnButton;
    [SerializeField]
    Button PutOffButton;

    [SerializeField]
    GameObject MainCanvas;
    [SerializeField]
    GameObject EquipCanvas;

    EquipData NowViewingEquipData = EquipData.nodata;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEquipDataButton();

        TrunOffAllCanvas();
        TrunOnMainCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipClicked()
    {
        TrunOffAllCanvas();
        TurnOnEquipCanvas();
    }

    public void OnDungeonClicked()
    {
        Debug.Log("OnDungeonClicked");
    }

    public void OnEquipDataButtonClicked(int ID)
    {
        Debug.Log(string.Format("OnEquipDataButtonClicked : {0}", ID));
        EquipData e = EquipManager.Instance.GetEquipDataById(ID);

        SetInfoTable(e);


    }

    public void OnPutonButtonClicked()
    {
        Debug.Log(string.Format("OnPutonButtonClicked : {0}", NowViewingEquipData.ID));
        if (NowViewingEquipData.ID == -1)
            return;

        EquipManager.Instance.PutOn(NowViewingEquipData.ID);
        SetInfoTable(NowViewingEquipData);
    }

    public void OnPutOffButtonClicked()
    {
        Debug.Log(string.Format("OnPutOffButtonClicked : {0}", NowViewingEquipData.ID));
        if (NowViewingEquipData.ID == -1)
            return;

        EquipManager.Instance.PutOff(NowViewingEquipData.ID);
        SetInfoTable(NowViewingEquipData);
    }

    public void SpawnEquipDataButton()
    {
        foreach (EquipData e in EquipManager.Instance.EquipDatas)
        {
            EquipDataButton edb = Instantiate(EquipDataButtonPrefab, EquipScrollbarContents).GetComponent<EquipDataButton>();

            edb.Init(this,e);

        }
    }

    

    private void SetInfoTable(EquipData e)
    {
        InfoIcon.sprite = e.icon;
        InfoText.text = e.info;
        InfoNameNext.text = e.name;

        NowViewingEquipData = e;

        bool isWearing = EquipManager.Instance.IsWaering(e.ID);

        PutOffButton.interactable = e.isValid && isWearing;
        PutOnButton.interactable = e.isValid && (!isWearing);

    }

    public void OnEquipCloseButton()
    {
        TrunOffAllCanvas();
        TrunOnMainCanvas();
    }

    private void TrunOnMainCanvas()
    {
        MainCanvas.SetActive(true);
    }

    private void TurnOnEquipCanvas()
    {
        EquipCanvas.SetActive(true);
    }

    private void TrunOffAllCanvas()
    {
        MainCanvas.SetActive(false);
        EquipCanvas.SetActive(false);
    }


}
