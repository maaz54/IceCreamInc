using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameSetting gameSetting;
    public IceCreamMaker iceCreamMaker;
    public BazierFollow ObjectiveBazier;

    public event Action<float> complete;
    public event Action gameStart;

    public GameObject cameraObjectiveShow;
    public static int LevelNo = 1;


    void Awake()
    {
        instance = this;


    }

    public void Complete(float matchPersantage)
    {
        complete?.Invoke(matchPersantage);

        LevelNo++;
        if (LevelNo > gameSetting.Objectives.Count)
        {
            LevelNo = 1;
        }

    }
    public void GameStart()
    {
        iceCreamMaker.icreamIndexes = ObjectiveBazier.CreateObjective(LevelNo, gameSetting);
        Invoke("OffObjectiveCamera", .5f);
        gameStart?.Invoke();
    }

    void OffObjectiveCamera()
    {
        cameraObjectiveShow.SetActive(false);
    }

}
