using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int _targetScore = 1000;

    public static int GameLevel = 1;

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
        BackgroundController.BgScrollSpeed = 1.0f;
        AdMediaController.S.ShowAdBanner(false);
    }
}
