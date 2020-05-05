using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button playBtn, pauseBtn;

    [SerializeField]
    private Text _messageTxt;
    [SerializeField]
    private Button _restartBtn, _mainMenuBtn, _quitBtn, _yesBtn, _noBtn;
    [SerializeField]
    private GameObject _guiPanel, _yesNoPanel;
    private string _buttonName = "";

    public static PauseController S;
    //public static bool isPaused = false;

    void Start()
    {
        S = this;
        playBtn.onClick.AddListener(PlayButtonOnClick);
        _restartBtn.onClick.AddListener(RestartButtonOnClick);
        _mainMenuBtn.onClick.AddListener(MainMenuButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
        _yesBtn.onClick.AddListener(YesButtonOnClick);
        _noBtn.onClick.AddListener(NoButtonClick);
    }

    void PlayButtonOnClick()
    {
        Time.timeScale = 1.0f;
        //isPaused = false;
        gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);
        _guiPanel.GetComponent<Image>().color = new Color(_guiPanel.GetComponent<Image>().color.r, _guiPanel.GetComponent<Image>().color.g, _guiPanel.GetComponent<Image>().color.b, 0.75f);
    }

    void RestartButtonOnClick() //=> SceneController.SceneSelect("02 - GameScene"); // TODO Reset score and level
    {
        _buttonName = "restart";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "RESTART GAME?";
        _messageTxt.fontSize = 29;
    }

    void MainMenuButtonOnClick() //=> SceneController.SceneSelect("01 - MainMenu");
    {
        _buttonName = "mainmenu";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "RETURN TO MAIN MENU?";
        _messageTxt.fontSize = 30;
    }

    void QuitButtonOnClick() //=> SceneController.SceneQuit();
    {
        _buttonName = "quit";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "QUIT GAME?";
        _messageTxt.fontSize = 34;
    }

    void YesButtonOnClick() // ADD MESSAGE e.g. Are you sure you want to quit game?
    {
        if (_buttonName == "restart") SceneController.SceneSelect("02 - GameScene");
        if (_buttonName == "mainmenu") SceneController.SceneSelect("01 - MainMenu");
        if (_buttonName == "quit") SceneController.SceneQuit();
        Time.timeScale = 1.0f;
    }

    void NoButtonClick()
    {
        _yesNoPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
