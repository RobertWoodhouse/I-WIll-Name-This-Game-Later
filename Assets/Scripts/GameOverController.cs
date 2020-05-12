using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text titleTxt, messageTxt;

    [SerializeField]
    private Button _retryBtn, _quitBtn;
    [SerializeField]
    private GameObject _guiPanel;

    public static GameOverController S;
    public static string Title, Message;

    void Start()
    {
        S = this;
        _retryBtn.onClick.AddListener(RetryButtonOnClick);
        _quitBtn.onClick.AddListener(QuitButtonOnClick);
        titleTxt.text = Title;
        messageTxt.text = Message;
    }

    void RetryButtonOnClick() //=> SceneController.SceneSelect("02 - GameScene"); // TODO Reset score and level
    {
        GameController.ResetStageStats();
        SceneController.SceneSelect("02 - GameScene");
        PauseController.PauseAndPlay(PauseController.PlaySpeed.Play);
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        gameObject.SetActive(false);
    }


    void QuitButtonOnClick() //=> SceneController.SceneQuit();
    {
        SceneController.SceneQuit();
        //PauseController.PauseAndPlay(PauseController.PlaySpeed.Play);
        //StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Play));
        //gameObject.SetActive(false);
    }
}
