using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/GameSetting", order = 1)]

public class GameSetting : ScriptableObject
{
    public List<Objectives> Objectives;
}


[System.Serializable]
public class Objectives
{
    public List<Cream> creams;
}
[System.Serializable]
public class Cream
{
    /// <summary>
    /// if we use More one Cream Colors We can assign them with Index
    /// </summary>
    public int Index;
    /// <summary>
    /// Cream Persantag in Ice cream
    /// </summary>
    public float CreamPersantage;

}
