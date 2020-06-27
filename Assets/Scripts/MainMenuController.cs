using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button backBtn;

    [SerializeField]
    private Text _headerTxt, _messageTxt;
    [SerializeField]
    private Button _playBtn, _selectShipBtn, _scoreBtn, _tutorialBtn, _quitBtn, _yesBtn, _noBtn;
    [SerializeField]
    private GameObject _selectShipWin, _scoreWin, _tutorialWin, _mainMenu, _yesNoPanel;

    public static MainMenuController S;

    void Start()
    {
        S = this;
        _playBtn.onClick.AddListener(PlayButtonOnClick);
        _selectShipBtn.onClick.AddListener(SelectShipButtonOnClick);
        _scoreBtn.onClick.AddListener(ScoreButtonOnClick);
        _tutorialBtn.onClick.AddListener(TutorialButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
        _yesBtn.onClick.AddListener(YesButtonOnClick);
        _noBtn.onClick.AddListener(NoButtonClick);
        if (backBtn.gameObject.activeSelf) backBtn.gameObject.SetActive(false);
        SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    public void SetHeaderText(string header) => _headerTxt.text = header;

    void PlayButtonOnClick() => SceneController.SceneSelect("02 - GameScene");

    void SelectShipButtonOnClick()
    {
        _mainMenu.SetActive(false);
        _selectShipWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("SELECT SHIP"); 
    }

    void ScoreButtonOnClick()
    {
        _mainMenu.SetActive(false);
        _scoreWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("SCORES");
    }

    void TutorialButtonOnClick()
    {
        _mainMenu.SetActive(false);
        _tutorialWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("TUTORIAL");
    }

    void QuitButtonOnClick()
    {
        _yesNoPanel.SetActive(true);
        _mainMenu.SetActive(false);
        _messageTxt.text = "QUIT GAME?";
        _messageTxt.fontSize = 34;
    }

    void YesButtonOnClick() => SceneController.SceneQuit();

    void NoButtonClick()
    {
        _yesNoPanel.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
