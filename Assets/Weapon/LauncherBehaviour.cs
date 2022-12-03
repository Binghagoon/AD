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
    float LaunchDelay = 2.0f;
    [SerializeField]
    float NumberOfLaunchAtOnce = 2;

    int nextLaunchPosition = 0;

    float timer = 0;
    public override void StartAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void StopAttack()
    {
        throw new System.NotImplementedException();
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

    private void Launch()
    {
        for (int i=0;i< NumberOfLaunchAtOnce; i++)
        {
            Transform next = getNextLaunchPosition();

            Instantiate(prefeb, next);
        }
    }

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        while(timer>= LaunchDelay)
        {
            timer -= LaunchDelay;
            Launch();
        }

    }
}
