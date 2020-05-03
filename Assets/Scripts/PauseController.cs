using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Button playBtn, pauseBtn;

    //[SerializeField]
    //private Text _headerTxt;
    [SerializeField]
    private Button _restartBtn, _mainMenuBtn, _quitBtn;
    [SerializeField]
    private GameObject _guiPanel;

    public static PauseController S;

    void Start()
    {
        S = this;
        playBtn.onClick.AddListener(PlayButtonOnClick);
        _restartBtn.onClick.AddListener(RestartButtonOnClick);
        _mainMenuBtn.onClick.AddListener(MainMenuButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
    }

    void PlayButtonOnClick()
    {
        gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);
        _guiPanel.GetComponent<Image>().color = new Color(_guiPanel.GetComponent<Image>().color.r, _guiPanel.GetComponent<Image>().color.g, _guiPanel.GetComponent<Image>().color.b, 0.75f);
    }

    void RestartButtonOnClick() => SceneController.SceneSelect("02 - GameScene"); // TODO Reset score and level

    void MainMenuButtonOnClick() => SceneController.SceneSelect("01 - MainMenu");

    void QuitButtonOnClick() => SceneController.SceneQuit();
}
