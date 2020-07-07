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

    void Start()
    {
        S = this;
        _retryBtn.onClick.AddListener(RetryButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
        _mainMenuBtn.onClick.AddListener(MainMenuButtonOnClick);
    }

    void RetryButtonOnClick()
    {
        GameController.ResetStageStats();
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        SceneController.SceneSelect("02 - GameScene");
        _gameOverPanel.SetActive(false);
    }

    void QuitButtonOnClick() => SceneController.SceneQuit();

    void MainMenuButtonOnClick()
    {
        GameController.ResetStageStats();
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        SceneController.SceneSelect("01 - MainMenu");
        _gameOverPanel.SetActive(false);
    }

    public void UpdateGameOverScreen(string title, string message)
    {
        titleTxt.text = title;
        messageTxt.text = message;
    }
}
