using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
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
        //GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f);
        _guiImage.color = new Color(_guiImage.color.r, _guiImage.color.g, _guiImage.color.b, 1f);
    }

    public void LoadGameOverPanel(int score) //FIXME correct messages displayed for getting scores in range
    {
        /*
        for(int i = 0; i < PlayerPrefsX.GetIntArray("HighScores").Length - 1; i++) // TEST
        {
            print("Score " + (i + 1) + ": " + PlayerPrefsX.GetIntArray("HighScores")[i]);
        }
        */

        _gameOverPanel.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        //gameObject.SetActive(false);
        _guiPanel.SetActive(false);
        int rand = Random.Range(0, _gameOverMessages.Length - 1);
        print("Random No. " + rand);

        if (score == PlayerPrefsX.GetIntArray("HighScores")[9])
        {
            //print("TEST HIGH SCORE");
            //GameOverController.Title = "NEW HIGH SCORE!";
            //GameOverController.Message = score.ToString();
            GameOverController.S.UpdateGameOverText("NEW HIGH SCORE!", score.ToString());
        }
        else if (score < PlayerPrefsX.GetIntArray("HighScores")[9] && score > PlayerPrefsX.GetIntArray("HighScores")[1])
        {
            //print("TEST MID SCORE");
            //GameOverController.Title = "YOU CRACKED THE TOP 10";
            //GameOverController.Message = score.ToString();
            GameOverController.S.UpdateGameOverText("YOU CRACKED THE TOP 10", score.ToString());
        }
        else if (score > 2000)
        {
            //print("TEST GAMEOVER");
            //GameOverController.Title = "GAME OVER";
            //GameOverController.Message = _gameOverMessages[rand];
            GameOverController.S.UpdateGameOverText("GAME OVER", _gameOverMessages[rand]);
        }
        else
        {
            // TODO Add random range for loser messages
            GameOverController.S.UpdateGameOverText("GAME OVER", _gameOverLoserMessages[1]);
        }
    }
}
