using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShipController : MonoBehaviour
{
    public Text nameTxt, descriptionTxt;
    public Image shipImg;

    //[SerializeField]
    //private Text _headerTxt; // TODO change to single static var
    [SerializeField]
    private Sprite[] _shipSprites;
    [SerializeField]
    private Button _leftBtn, _rightBtn, _backBtn;
    [SerializeField]
    private GameObject _mainMenu;
    private int _selectNum = 0;
    private string[] _names = { "SIR LENWORTH", "S.S. BUC NASTY", "BANTON CHRONICLE" };
    private string[] _descriptions =
    {
        "SIR LENWORTH IS FAST \nUNPARALLELED SPEED",
        "FROM THE US MILLITARY \nTHEY SAY THE SKY IS COVERED IN DARKNESS WHEN THIS SHIP RAINS GUNFIRE \nTHE S.S. BUC NASTY BOASTS SUPERIOR FIRE POWER",
        "FRESH FROM THE HILLS OF JA \nTHE BANTON CHRONICLE \n\"DUPPY KNOW WHO FI FRIGHTEN\" \nMAXIMUM SPEED AND FIRE POWER"
    };

    void Start()
    {
        SelectShip(0); // TODO save last ship selected on phone memory
        _leftBtn.onClick.AddListener(LeftButtonOnClick);
        _rightBtn.onClick.AddListener(RightButtonOnClick);
        _backBtn.onClick.AddListener(BackButtonOnClick);
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

    void SelectShip(int select)
    {
        nameTxt.text = _names[select];
        descriptionTxt.text = _descriptions[select];
        shipImg.sprite = _shipSprites[select];
    }
}
