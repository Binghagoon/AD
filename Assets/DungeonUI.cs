using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DungeonUI : MonoBehaviour
{

    DungeonManager dungeonManager;

    [SerializeField]
    TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        dungeonManager = FindObjectOfType<DungeonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = string.Format("{0:0.00}",dungeonManager.RemainTime);
    }
}
