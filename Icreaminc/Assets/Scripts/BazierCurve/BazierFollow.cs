using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BazierFollow : MonoBehaviour
{
    public Transform[] routes;
    int routToGO;
    float tParam;
    Vector3 playerPosition;
    public float speedModifier;
    public bool coroutineAllowed;

    public List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        routToGO = 0;
        tParam = 0;
        transform.parent = null;
        coroutineAllowed = true;
        positions.Clear();
        GotoRoute(routToGO);
    }

    public List<int> icreamIndexes;
    public List<int> CreateObjective(int level, GameSetting gameSetting)
    {
        icreamIndexes.Clear();
        for (int i = 0; i < gameSetting.Objectives[level - 1].creams.Count; i++)
        {
            int t = Mathf.CeilToInt(((float)(positions.Count) / 100) * (float)gameSetting.Objectives[level - 1].creams[i].CreamPersantage);
            for (int j = 0; j < t; j++)
            {
                icreamIndexes.Add(gameSetting.Objectives[level - 1].creams[i].Index);
            }
        }
        try
        {
            IceCreamDemo();
        }
        catch {
            Debug.Log("Edge Case Issue");
        }
        return icreamIndexes;
    }

    public GameObject[] scoops;
    void IceCreamDemo()
    {
        for (int i = 0; i < positions.Count; i++)
            {
            GameObject go = Instantiate(scoops[icreamIndexes[i]-1]);
            go.SetActive(true);
            go.transform.position = positions[i];
            go.transform.parent = this.transform;
        }
    }

    private void GotoRoute(int routeNumber)
    {
        coroutineAllowed = false;


        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;
        while (tParam < 1)
        {
            tParam += speedModifier;
            playerPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            positions.Add(playerPosition);
        }

        tParam = 0f;
        routToGO += 1;

        if (routToGO > routes.Length - 1)
        {
            routToGO = 0;
        }
        else
        {
            GotoRoute(routToGO);
        }

    }
}
