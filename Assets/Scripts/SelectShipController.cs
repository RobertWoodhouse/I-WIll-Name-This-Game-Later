﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShipController : MonoBehaviour
{
    public Text nameTxt, descriptionTxt;
    public Image shipImg;
    public static bool IsShip2Locked = true, IsShip3Locked = true;

    //[SerializeField]
    //private Text _headerTxt; // TODO change to single static var
    [SerializeField]
    private Sprite[] _shipSprites;
    [SerializeField]
    private Sprite _shipLockedSprite;
    [SerializeField]
    private Button _leftBtn, _rightBtn, _backBtn, _selectBtn, _adBtn;
    [SerializeField]
    private GameObject _mainMenu;
    public int _selectNum = 0;
    private string[] _names = { "SIR LENWORTH", "S.S. BUC NASTY", "BANTON CHRONICLE" };
    private string[] _descriptions =
    {
        "SIR LENWORTH IS FAST \nUNPARALLELED SPEED",
        "FROM THE US MILLITARY \nTHEY SAY THE SKY IS COVERED IN DARKNESS WHEN THIS SHIP RAINS GUNFIRE \nTHE S.S. BUC NASTY BOASTS SUPERIOR FIRE POWER",
        "FRESH FROM THE HILLS OF JA \nTHE BANTON CHRONICLE \n\"DUPPY KNOW WHO FI FRIGHTEN\" \nMAXIMUM SPEED AND FIRE POWER"
    };

    private void Awake()
    {
        /*
        IsShip2Locked = PlayerPrefsX.GetBool("Ship2Locked");
        IsShip3Locked = PlayerPrefsX.GetBool("Ship3Locked");
        */
    }

    private void Start()
    {
        SelectShip(0); // TODO save last ship selected on phone memory
        _adBtn.gameObject.SetActive(false);
        _leftBtn.onClick.AddListener(LeftButtonOnClick);
        _rightBtn.onClick.AddListener(RightButtonOnClick);
        _backBtn.onClick.AddListener(BackButtonOnClick);
        _selectBtn.onClick.AddListener(SelectButtonOnClick);
        _adBtn.onClick.AddListener(AdButtonOnClick);
    }

    void LeftButtonOnClick()
    {
        _selectNum--;
        if (_selectNum < 0) _selectNum = (_shipSprites.Length - 1);
        SelectShip(_selectNum);
    }

    void RightButtonOnClick()
    {
        _selectNum++;
        if (_selectNum > (_shipSprites.Length - 1)) _selectNum = 0;
        SelectShip(_selectNum);
    }

    void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }


    void AdButtonOnClick()
    {
        _adBtn.gameObject.SetActive(false);
        AdMediaController.S.ShowAdRewardedVideo();
    }

    void SelectButtonOnClick() // TODO SET PLAYER SHIP SPAWN SHIP ON LOAD
    {
    }

    void SelectShip(int select)
    {
        if (IsShip2Locked && select == 1)
        {
            nameTxt.text = "???";
            descriptionTxt.text = "PLAY AD VIDEO TO UNLOCK SHIP";
            shipImg.sprite = _shipLockedSprite;
            _adBtn.gameObject.SetActive(true);
            _selectBtn.interactable = false;
        }
        else if (IsShip3Locked && select == 2)
        {
            nameTxt.text = "???";
            descriptionTxt.text = "GET A SCORE OF 100000 TO UNLOCK SHIP";
            shipImg.sprite = _shipLockedSprite;
            _adBtn.gameObject.SetActive(false);
            _selectBtn.interactable = false;
        }
        else
        {
            nameTxt.text = _names[select];
            descriptionTxt.text = _descriptions[select];
            shipImg.sprite = _shipSprites[select];
            _adBtn.gameObject.SetActive(false);
            _selectBtn.interactable = true;
        }
    }
}
