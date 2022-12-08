using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : MonoBehaviour
{
    public bool isShaking;

    [SerializeField]
    bool autoOpen = false;
    [SerializeField]
    float HP = 3f;
    [SerializeField]
    float openAngle;
    [SerializeField]
    bool isOpened = false;
    [SerializeField]
    float shakeTimeout = 1f;
    float shakeDecay = 0.003f;
    float shakeIntensity = 0.5f;
    float frequency = 0.3f;
    float amplitude = 100f;
    float shakeTimestamp;
    Vector3 directionOfShake = Vector3.forward;
    Vector3 originPosition;
    Vector3 originRotation;


    GameObject Down, Up;
    float originIntensity;

    public void Attack(float damage)
    {
        if (HP < 0) return;
        HP -= damage;
        Shake();
        if (HP < 0) ShakeEnd();
    }

    void Start()
    {
        Up = gameObject.transform.GetChild(0).gameObject;
        Down = gameObject.transform.GetChild(1).gameObject;
        originPosition = transform.position;
        originRotation = transform.rotation.eulerAngles;
        originIntensity = shakeIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking) Shake();
        if (autoOpen) Attack(Time.deltaTime);
        if (Time.realtimeSinceStartup - shakeTimestamp > shakeTimeout) isShaking = false;
        if (isOpened) OpenChest();
    }

    void Shake()
    {
        if (!isShaking)
        {
            isShaking = true;
            shakeTimestamp = Time.realtimeSinceStartup;
        }
        transform.position = originPosition + directionOfShake * Mathf.Sin(frequency * Time.deltaTime) * amplitude;
        //Upper code is refered by https://stackoverflow.com/questions/62061676/how-to-vibrate-an-object-with-unity-3d
    }
    void ShakeEnd()
    {
        if (isOpened)
        {
            Debug.Log("Already Chest is opened.");
            return;
        }
        isShaking = false;
        isOpened = true;
        OpenChest();
    }

    void OpenChest()
    {
        Transform transform = Up.transform;
        Vector3 to = new Vector3(openAngle, 0, 0);
        if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = to;
        }
    }

}
