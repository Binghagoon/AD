using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipDataButton : MonoBehaviour
{

    MainUI mainUi;
    [SerializeField]
    int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipDataButtonClicked()
    {
        mainUi.OnEquipDataButtonClicked(ID);
    }

    public void Init(MainUI _mainUi,EquipData equipData)
    {
        Image image = GetComponent<Image>();
        image.sprite = equipData.icon;
        ID = equipData.ID;

        Button button = GetComponent<Button>();
        //button.interactable = equipData.isValid;

        mainUi = _mainUi;
    }
}

