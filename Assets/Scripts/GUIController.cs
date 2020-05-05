using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Button playBtn, pauseBtn;

    [SerializeField]
    private Text _scoreTxt, _levelTxt;
    [SerializeField]
    private GameObject _pauseMenu;

    public static GUIController S;

    void Start()
    {
        S = this;
        pauseBtn.onClick.AddListener(PauseButtonOnClick);
    }

    void Update()
    {
        _scoreTxt.text = "SCORE: " + GameController.Score;
        _levelTxt.text = "LEVEL: " + GameController.GameLevel;
    }

    void PauseButtonOnClick()
    {
        Time.timeScale = 0.0f;
        //PauseController.isPaused = true;
        //gameObject.SetActive(false);
        _pauseMenu.SetActive(true);
        playBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f);
    }
}
