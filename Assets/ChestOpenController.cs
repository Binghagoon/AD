using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenController : MonoBehaviour
{
    public int openAngle = 45;
    private bool rotating = false;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: 요 부분 추후 흔들기 상호작용 시 열림으로 수정
        OpenChest();
    }

    public void OpenChest()
    {
        rotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            Vector3 to = new Vector3(openAngle, 0, 0);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
            }
            else
            {
                transform.eulerAngles = to;
                rotating = false;
            }
        }
    }
}
