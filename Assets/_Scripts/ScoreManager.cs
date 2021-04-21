using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance

    {
        get
        {
            if (_instance == null)
                Debug.Log("Error instance GameManger is null.");

            return _instance;
        }
    }

    private Text _scoreTxt;
    public int score = 5;


    void Awake()
    {
        _instance = this;

        _scoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();

    }

    public void ScoreSub()
    {
        if (score > 1)
            score--;
        else
        {
            score = 0;
        }

        _scoreTxt.text = score.ToString("D2");
    }


    public void StartGame()
    {
        score = 5;
        _scoreTxt.text = score.ToString("D2");

    }

}
