using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text titleTxt, messageTxt;

    [SerializeField]
    private Button _retryBtn, _quitBtn, _mainMenuBtn;
    [SerializeField]
    private GameObject _guiPanel, _gameOverPanel;

    public static GameOverController S;
    //public static string Title, Message;

    void Start()
    {
        S = this;
        _retryBtn.onClick.AddListener(RetryButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
        _mainMenuBtn.onClick.AddListener(MainMenuButtonOnClick);
        //titleTxt.text = Title;
        //messageTxt.text = Message;
    }

    void RetryButtonOnClick() //=> SceneController.SceneSelect("02 - GameScene"); // TODO Reset score and level
    {
        GameController.ResetStageStats();
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        SceneController.SceneSelect("02 - GameScene");
        //gameObject.SetActive(false);
        _gameOverPanel.SetActive(false);
    }

    void QuitButtonOnClick() => SceneController.SceneQuit();

    void MainMenuButtonOnClick() //=> SceneController.SceneSelect("02 - GameScene"); // TODO Reset score and level
    {
        GameController.ResetStageStats();
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        SceneController.SceneSelect("01 - MainMenu");
        //gameObject.SetActive(false);
        _gameOverPanel.SetActive(false);
    }

    public void UpdateGameOverText(string title, string message)
    {
        titleTxt.text = title;
        messageTxt.text = message;
    }
}
