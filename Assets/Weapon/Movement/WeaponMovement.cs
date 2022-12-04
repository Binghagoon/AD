using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    /// <summary>
    /// Must be implemented
    /// </summary>
    /// <param name="deltatime"></param>
    /// <param name="target"></param>
    public virtual void MoveToTarget(float deltatime,Transform target)
    {

    }

    public virtual void SetTarget(Transform target)
    {

    }
}
