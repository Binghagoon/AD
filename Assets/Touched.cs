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

    // �ʿ��ѵ��� �θ��� ���� ��鸮�� �� �ִٰ� ����
    // If call this function than a chest is shaked and then the chest is opened. I can't download hangul so add it.
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