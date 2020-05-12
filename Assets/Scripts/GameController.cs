using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _targetScore = 1000;

    public static int GameLevel = 1/*, Score = 0*/;
    //private static List<int> _HighScores = new List<int>();

    private void FixedUpdate()
    {
        IncreaseLevel(ScoreController.Score);
    }

    public void IncreaseLevel(int score)
    {
        if (score >= _targetScore)
        {
            GameLevel++;
            _targetScore += 1000;
            BackgroundController.BgScrollSpeed += 0.75f; // Increase BG scroll speed
        }
    }

    public static void ResetStageStats()
    {
        GameLevel = 1;
        ScoreController.Score = 0;
        AdMediaController.S.ShowAdBanner(false);
    }
    /*
    public static void SetHighScoreTable(int score)
    {
        _HighScores.Sort();
        if (score > _HighScores[0])
        {
            for (int i = 1; i < _HighScores.Count - 1; i++)
            {
                if (score < _HighScores[i])
                {
                    print("Score added: " + score);
                    _HighScores.Insert(i, score);
                    _HighScores.RemoveAt(0);
                    break;
                }
            }
            PlayerPrefsX.SetIntArray("HighScores", _HighScores.ToArray());
        }
    }
    */
}
