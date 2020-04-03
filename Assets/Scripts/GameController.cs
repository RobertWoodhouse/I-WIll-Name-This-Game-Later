using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int GameLevel = 1;
    public static int Score = 0;

    [SerializeField]
    private int _targetScore = 1000;

    public void Update()
    {
        IncreaseLevel(Score);
    }

    public void IncreaseLevel(int score)
    {
        if (score >= _targetScore)
        {
            GameLevel++;
            _targetScore += 1000;
        }
        //print("Score = " + Score + " | Game Level = " + GameLevel + " | Target Score = " + _targetScore);
    }
}
