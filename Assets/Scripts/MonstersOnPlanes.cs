using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MonstersOnPlanes : MonoBehaviour
{
    [SerializeField]
    MonsterManager monsterManager;
    [SerializeField]
    ARPlaneManager planeManager;

    int planeCount = -1;
    List<(Vector3, Vector3)> squares = new List<(Vector3, Vector3)>();

    // Start is called before the first frame update
    void Start()
    {
        if(monsterManager == null)
        {
            Debug.Log("Please set monsterManager in ARPlane.cs");
            monsterManager = FindObjectOfType<MonsterManager>();
        }
        if(planeManager == null)
        {
            Debug.Log("Please set planeManager in ARPlane.cs");
            planeManager = FindObjectOfType<ARPlaneManager>();
        }
    }

    void UpdateRactangle()
    {

    }
    (Vector3, Vector3) ReturnVerticesOfRactangle(Vector3 center, Vector2 size, Vector3 normal)
    {
        Vector3[] vertices = new Vector3[4];
        Vector3 right = Vector3.Cross(normal, Vector3.up);
        Vector3 up = Vector3.Cross(right, normal);
        return (center + right * size.x / 2 + up * size.y / 2, center - right * size.x / 2 - up * size.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        TrackableCollection<ARPlane> trackables = planeManager.trackables;
        monsterManager.spawnerActive = planeCount > 0;
        if (trackables.count > planeCount)
        {
            planeCount = trackables.count;
            foreach (var plane in trackables)
            {
                (Vector3, Vector3) square = ReturnVerticesOfRactangle(plane.center, plane.size, plane.normal);
                if(!squares.Contains(square))
                {
                    squares.Add(square);
                    monsterManager.addSquare(square.Item1, square.Item2);
                }
            }
        }
        else if (trackables.count < planeCount)
        {
            planeCount = trackables.count;
            List<int> squareNum = new List<int>();
            foreach (var plane in trackables)
            {
                (Vector3, Vector3) square = ReturnVerticesOfRactangle(plane.center, plane.size, plane.normal);
                squareNum.Add(squares.IndexOf(square));
            }
            foreach(var square in squares)
            {
                if(!squareNum.Contains(squares.IndexOf(square)))
                {
                    squares.Remove(square);
                    monsterManager.removeSquare(square.Item1, square.Item2);
                }
            }
            //Is that good approach?
        }
    }
}
