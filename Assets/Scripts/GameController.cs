using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int GameLevel = 1, Score = 0;

    [SerializeField]
    private int _targetScore = 1000;
    [SerializeField]
    //private Text _scoreTxt, _levelTxt;


    public void Update()
    {
        IncreaseLevel(Score);
        /*
        _scoreTxt.text = "SCORE: " + Score;
        _levelTxt.text = "LEVEL: " + GameLevel;
        */
    }

    public void IncreaseLevel(int score)
    {
        if (score >= _targetScore)
        {
            GameLevel++;
            _targetScore += 1000;
            BackgroundController.BgScrollSpeed += 0.75f; // Increase BG scroll speed
        }
        //print("Score = " + Score + " | Game Level = " + GameLevel + " | Target Score = " + _targetScore);
    }
}
