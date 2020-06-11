using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public AudioClip[] clipHighScoreSFX, clipTopTenSFX, clipGameOverSFX, clipGameOverLoserSFX;

    [SerializeField]
    private Button _playBtn, _pauseBtn;
    [SerializeField]
    private Text _scoreTxt, _levelTxt;
    [SerializeField]
    private GameObject _pauseMenu, _gameOverPanel, _guiPanel;
    private Image _guiImage;
    private string[] _gameOverMessages, _gameOverLoserMessages;

    public static GUIController S;

    void Start()
    {
        _guiImage = _guiPanel.GetComponent<Image>();
        _gameOverMessages = new string[] { "A GEM CANNOT BE POLISHED WITHOUT FRICTION, NOR A MAN PERFECTED WITHOUT TRIALS", "WITHIN EVERY OBSTACLE IS AN OPPORTUNITY TO IMPROVE YOUR CONDITION", "WHAT IS DEFEAT? NOTHING BUT THE FIRST STEPS TO SOMETHING BETTER", "WINNERS NEVER QUIT, QUITTERS NEVER WIN" };
        _gameOverLoserMessages = new string[] { "DAT NUH LOOK GOOD...", "NAH FAM, YOU'RE HAVING A LAUGH", "IS THAT IT?!" , "WEAK!...", "THIS A JOKE TING"};
        S = this;
        _pauseBtn.onClick.AddListener(PauseButtonOnClick);
    }

    void Update()
    {
        _scoreTxt.text = "SCORE: " + ScoreController.Score;
        _levelTxt.text = "LEVEL: " + GameController.GameLevel;
    }

    void PauseButtonOnClick()
    {
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Pause));
        _pauseMenu.SetActive(true);
        _playBtn.gameObject.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        _guiImage.color = new Color(_guiImage.color.r, _guiImage.color.g, _guiImage.color.b, 1f);
    }

    public void LoadGameOverPanel(int score)
    {
        /*
        for(int i = 0; i < PlayerPrefsX.GetIntArray("HighScores").Length; i++) // TEST
        {
            print("Score " + (i + 1) + ": " + PlayerPrefsX.GetIntArray("HighScores")[i]);
        }
        print("Current score: " + score);
        */

        _gameOverPanel.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        _guiPanel.SetActive(false);
        int rand = Random.Range(0, _gameOverMessages.Length - 1);
        int randLose = Random.Range(0, _gameOverLoserMessages.Length - 1);

        //print("Random No. " + rand);

        if (score > PlayerPrefsX.GetIntArray("HighScores")[0])
        {
            print("TEST HIGH SCORE");
            GameOverController.S.UpdateGameOverScreen("NEW HIGH SCORE!", score.ToString());
            GameEvents.S.PlaySFX(clipHighScoreSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else if (score >= PlayerPrefsX.GetIntArray("HighScores")[9] && score <= PlayerPrefsX.GetIntArray("HighScores")[0])
        {
            print("TEST MID SCORE");
            GameOverController.S.UpdateGameOverScreen("YOU CRACKED THE TOP 10", score.ToString());
            GameEvents.S.PlaySFX(clipTopTenSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else if (score > 1500)
        {
            print("TEST GAMEOVER");
            GameOverController.S.UpdateGameOverScreen("GAME OVER", _gameOverMessages[rand]);
            GameEvents.S.PlaySFX(clipGameOverSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else
        {
            GameOverController.S.UpdateGameOverScreen("GAME OVER", _gameOverLoserMessages[randLose]);
            GameEvents.S.PlaySFX(clipGameOverLoserSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
    }
}
