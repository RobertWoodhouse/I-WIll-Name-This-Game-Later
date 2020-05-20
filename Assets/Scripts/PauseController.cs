﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public enum PlaySpeed { Play, SlowMotion, Pause }

    public Button playBtn, pauseBtn;

    [SerializeField]
    private Text _messageTxt;
    [SerializeField]
    private Button _restartBtn, _mainMenuBtn, _quitBtn, _yesBtn, _noBtn;
    [SerializeField]
    private GameObject _guiPanel, _yesNoPanel;
    private string _buttonName = "";

    public static PauseController S;

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
        StartCoroutine(PauseAndPlay(PlaySpeed.Play));
        gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(false);
        _guiPanel.GetComponent<Image>().color = new Color(_guiPanel.GetComponent<Image>().color.r, _guiPanel.GetComponent<Image>().color.g, _guiPanel.GetComponent<Image>().color.b, 0.75f);
    }

    void RestartButtonOnClick()
    {
        _buttonName = "restart";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "RESTART GAME?";
        _messageTxt.fontSize = 29;
    }

    void MainMenuButtonOnClick()
    {
        _buttonName = "mainmenu";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "RETURN TO MAIN MENU?";
        _messageTxt.fontSize = 30;
    }

    void QuitButtonOnClick()
    {
        _buttonName = "quit";
        _yesNoPanel.SetActive(true);
        gameObject.SetActive(false);
        _messageTxt.text = "QUIT GAME?";
        _messageTxt.fontSize = 34;
    }

    void YesButtonOnClick() // TODO ADD MESSAGE e.g. Are you sure you want to quit game?
    {
        if (_buttonName == "restart") SceneController.SceneSelect("02 - GameScene");
        if (_buttonName == "mainmenu") SceneController.SceneSelect("01 - MainMenu");
        if (_buttonName == "quit") SceneController.SceneQuit();
        StartCoroutine(PauseAndPlay(PlaySpeed.Play));
        GameController.ResetStageStats();
    }

    void NoButtonClick()
    {
        _yesNoPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public static IEnumerator PauseAndPlay(PlaySpeed speed)
    {
        if (speed == PlaySpeed.SlowMotion)
        {
            print("Slow time");
            Time.timeScale = 0.25f;
            yield return new WaitForSeconds(0.25f);
            print("Slower time");
            Time.timeScale = 0.15f;
            yield return new WaitForSeconds(0.25f);
            print("Even Slower time");
            Time.timeScale = 0.05f;
        }
        if (speed == PlaySpeed.Play) Time.timeScale = 1.0f;
        if (speed == PlaySpeed.Pause) Time.timeScale = 0.0f;
    }
}