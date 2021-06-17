using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IceCreamMaker : MonoBehaviour
{
    public Slider ProgressBar;
    public GameObject[] scoops;
    public BazierFollow bazier;
    public List<Vector3> scopeSpline;
    int currentScopIndex = 0;

    bool canPlay = false;
    public List<int> icreamIndexes;
    int input=0;//scope1
    //bool input2;//scope2
    void Start()
    {
        GameManager.instance.gameStart += GameStart;
    }


    public float flowRate;
    float flow;
    private void Update()
    {
        if (canPlay)
        {
            if (input !=0)
            {
                flow += Time.deltaTime;
                if (flow >= flowRate)
                {
                    flow = 0;
                    CreateScope(input);
                }
            }
        }
    }
    public float Speed;



    int score=0;
    void CreateScope(int input)
    {
        GameObject go = Instantiate(scoops[input-1]);
        go.SetActive(true);
        go.transform.position = transform.position;
        go.transform.DOMove(scopeSpline[currentScopIndex], Speed);
        ProgressBar.value = currentScopIndex;
        if (input == icreamIndexes[currentScopIndex])
        {
            score++;
        }
        currentScopIndex++;


        if (currentScopIndex >= scopeSpline.Count)
        {
            float persantage = (float)score / (float)(icreamIndexes.Count);
            persantage = persantage * 100;
            Debug.Log("Score : " + persantage + "%");
            GameManager.instance.Complete(persantage);
            canPlay = false;
        }

    }
    public void inputScope(int i)
    {
        input = i;
    }


    void GameStart()
    {
        canPlay = true;
        scopeSpline = bazier.positions;
        ProgressBar.maxValue = scopeSpline.Count;
        ProgressBar.minValue = 0;
    }

}
