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
    private GameObject _pauseMenu, _gameOverPanel;
    //private string[] _gameOverMessages = { "A GEM CANNOT BE POLISHED WITHOUT FRICTION, NOR A MAN PERFECTED WITHOUT TRIALS", "THE OBSTACLE IN THE PATH BECOMES THE PATH, NEVER FORGET, WITHIN EVERY OBSTACLE IS AN OPPORTUNITY TO IMPROVE OUR CONDITION", "WHAT IS DEFEAT? NOTHING BUT EDUCATION; NOTHING BUT THE FIRST STEPS TO SOMETHING BETTER"};
    private string[] _gameOverMessages;

    public static GUIController S;

    void Start()
    {
        _gameOverMessages = new string[] { "A GEM CANNOT BE POLISHED WITHOUT FRICTION, NOR A MAN PERFECTED WITHOUT TRIALS", "THE OBSTACLE IN THE PATH BECOMES THE PATH, NEVER FORGET, WITHIN EVERY OBSTACLE IS AN OPPORTUNITY TO IMPROVE OUR CONDITION", "WHAT IS DEFEAT? NOTHING BUT EDUCATION; NOTHING BUT THE FIRST STEPS TO SOMETHING BETTER" };
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
        //Time.timeScale = 0.0f;
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Pause));
        //PauseController.PauseAndPlay(PauseController.PlaySpeed.Pause);
        //PauseController.isPaused = true;
        //gameObject.SetActive(false);
        _pauseMenu.SetActive(true);
        _playBtn.gameObject.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f);
    }

    public void LoadGameOverPanel(int score) // TODO create string array for quites
    {
        _gameOverPanel.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        gameObject.SetActive(false);
        var rand = Random.Range(0, _gameOverMessages.Length - 1);

        if (score > PlayerPrefsX.GetIntArray("HighScores")[0])
        {
            GameOverController.Title = "NEW HIGH SCORE!";
            GameOverController.Message = score.ToString();
        }
        else if (score > PlayerPrefsX.GetIntArray("HighScores")[9] && score < PlayerPrefsX.GetIntArray("HighScores")[1])
        {
            GameOverController.Title = "YOU CRACKED THE TOP 10";
            GameOverController.Message = score.ToString();
        }
        else
        {
            GameOverController.Title = "GAME OVER";
            //GameOverController.Message = "A GEM CANNOT BE POLISHED WITHOUT FRICTION, NO A MAN PERFECTED WITHOUT TRIALS";
            GameOverController.Message = _gameOverMessages[rand];

        }

    }
}
