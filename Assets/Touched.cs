using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touched : MonoBehaviour
{
    private ChestOpenController boxTop = null;
    private ObjectShake boxBottom = null;

    // Start is called before the first frame update
    void Start()
    {
        // Shakeit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 필요한데서 부르면 상자 흔들리고 좀 있다가 열림
    public void Shakeit()
    {
        Debug.Log("Shakeit has started");
        GameObject Top = GameObject.Find("Treasure_Chest_Up");
        GameObject Bottom = GameObject.Find("Treasure_Chest_Down");
        Debug.Log(Top);
        Debug.Log(Bottom);

        boxTop = Top.GetComponent<ChestOpenController>();
        boxBottom = Bottom.GetComponent<ObjectShake>();

        boxBottom.Shake();
        boxTop.Invoke("OpenChest", 0.9f);
        Debug.Log("Shakeit has ended");
    }
}