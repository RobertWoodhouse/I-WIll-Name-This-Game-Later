using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button backBtn;

    [SerializeField]
    private Text _headerTxt;
    [SerializeField]
    private Button _playBtn, _selectShipBtn, _scoreShipBtn, _tutorialShipBtn;
    [SerializeField]
    private GameObject /*_mainMenu,*/ _selectShipWin, _scoreWin, _tutorialWin;

    public static MainMenuController S;

    void Start()
    {
        S = this;
        _playBtn.onClick.AddListener(PlayButtonOnClick);
        _selectShipBtn.onClick.AddListener(SelectShipButtonOnClick);
        _scoreShipBtn.onClick.AddListener(ScoreButtonOnClick);
        _tutorialShipBtn.onClick.AddListener(TutorialButtonOnClick);
        if (backBtn.gameObject.activeSelf) backBtn.gameObject.SetActive(false);
        SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    public void SetHeaderText(string header) => _headerTxt.text = header;

    void PlayButtonOnClick() => SceneController.SceneSelect("02 - GameScene");

    void SelectShipButtonOnClick()
    {
        //_mainMenu.SetActive(false);
        gameObject.SetActive(false);
        _selectShipWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("SELECT SHIP"); 
    }

    void ScoreButtonOnClick()
    {
        //_mainMenu.SetActive(false);
        gameObject.SetActive(false);
        _scoreWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("SCORE");
    }

    void TutorialButtonOnClick()
    {
        //_mainMenu.SetActive(false);
        gameObject.SetActive(false);
        _tutorialWin.SetActive(true);
        backBtn.gameObject.SetActive(true);
        SetHeaderText("TUTORIAL");
    }
}
