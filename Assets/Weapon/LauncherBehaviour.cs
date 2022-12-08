using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBehaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefeb;
    [SerializeField]
    Transform[] LaunchPositions;
    [SerializeField]
    float[] LaunchDelayCycle = { 2.0f };
    [SerializeField]
    float NumberOfLaunchAtOnce = 2;

    float LaunchDelay;
    int nextLaunchPosition = 0;
    int nextDelay = 0;

    float timer = 0;

    bool isLaunching;
    public override void StartAttack()
    {
        isLaunching = true;
    }

    public override void StopAttack()
    {
        isLaunching = false;
    }

    private Transform getNextLaunchPosition()
    {
        if (LaunchPositions.Length == 0)
        {
            return transform;
        }
        else
        {
            nextLaunchPosition %= LaunchPositions.Length;
            return LaunchPositions[nextLaunchPosition++];
        }
    }

    private float GetNextDelay()
    {
        nextDelay %= LaunchDelayCycle.Length;
        return LaunchDelayCycle[nextDelay++];
    }

    private void Launch()
    {
        for (int i=0;i< NumberOfLaunchAtOnce; i++)
        {
            Transform next = getNextLaunchPosition();

            WeaponBehaviour newweapon = Instantiate(prefeb, next).GetComponent<WeaponBehaviour>();

            Debug.Log("AD| Weapon Spawned");
            Debug.Log(string.Format("AD| {0}", newweapon.name));
            //Debug.Log(newweapon.transform.position);

            newweapon.SetAttack(Attack);

        }
    }

    void Start()
    {
        timer = 0;
        LaunchDelay = GetNextDelay();
        StartAttack();//tmp
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        while(timer>= LaunchDelay)
        {
            timer -= LaunchDelay;
            LaunchDelay = GetNextDelay();
            Launch();
        }

    }
}
