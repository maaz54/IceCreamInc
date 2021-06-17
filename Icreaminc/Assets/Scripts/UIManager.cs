using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Button startButton;
    public Button nextButton;

    public GameObject go_Menu;
    public GameObject go_GamePlay;
    public GameObject go_LevelComplete;

    public Text MatchPersantageText;
    public Text LevelNoText;

    void Start()
    {
        startButton.onClick.AddListener(() => { StartGame(); });
        nextButton.onClick.AddListener(() => { NExtGame(); });
        GameManager.instance.complete += LevelComplete;
    }

    public void StartGame()
    {
        go_Menu.SetActive(false);
        go_GamePlay.SetActive(true);
        go_LevelComplete.SetActive(false);
        GameManager.instance.GameStart();
        LevelNoText.text = "Level : "+GameManager.LevelNo;
    }
    public void NExtGame()
    {
        Application.LoadLevel(0);
    }
    void LevelComplete(float persantage)
    {
        MatchPersantageText.text = "Match : " + (int)persantage + "%";
        go_Menu.SetActive(false);
        go_GamePlay.SetActive(false);
        go_LevelComplete.SetActive(true);
    }
}
