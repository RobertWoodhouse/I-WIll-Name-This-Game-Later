using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Text titleTxt, instructionsTxt;
    public Image tutImg1, tutImg2, tutImg3;
    /*
    [SerializeField]
    private Text _headerTxt; // TODO change to single static var
    */
    
    [SerializeField]
    private Sprite _shipSprite, _arrowSprite, _handSprite, _handTapSprite, _bulletSprite, _powerUpSprite, _speedUpSprite, _metalSprite, _satSprite;
    private int _selectNum = 1;

    [SerializeField]
    private Button _leftBtn, _rightBtn, _backBtn;
    [SerializeField]
    private GameObject _mainMenu;

    void Start()
    {
        _backBtn.onClick.AddListener(BackButtonOnClick);
        _leftBtn.onClick.AddListener(LeftButtonOnClick);
        _rightBtn.onClick.AddListener(RightButtonOnClick);
    }

    void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    void LeftButtonOnClick()
    {
        _selectNum--;
        if (_selectNum < 1) _selectNum = 1;
        SelectTutorial(_selectNum);
    }

    void RightButtonOnClick()
    {
        _selectNum++;
        if (_selectNum > 4) _selectNum = 4;
        SelectTutorial(_selectNum);
    }

    void SelectTutorial(int select)
    {
        _selectNum = select;

        switch (_selectNum)
        {
            case 1:
                titleTxt.text = "SHIP MOVEMENT";
                instructionsTxt.text = "TOUCH & HOLD SCREEN TO MOVE YOUR SHIP LEFT OR RIGHT";

                tutImg1.sprite = _shipSprite;
                tutImg1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-70, 64);
                tutImg1.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -10);
                tutImg1.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

                tutImg2.sprite = _arrowSprite;
                tutImg2.GetComponent<RectTransform>().anchoredPosition = new Vector2(8.5f, 64);
                tutImg2.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg2.GetComponent<RectTransform>().sizeDelta = new Vector2(47, 32.5f);

                tutImg3.sprite = _handSprite;
                tutImg3.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 64);
                tutImg3.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg3.GetComponent<RectTransform>().sizeDelta = new Vector2(57, 73.5f);
                tutImg3.gameObject.SetActive(true);
                break;

            case 2:
                titleTxt.text = "FIRE GUN";
                instructionsTxt.text = "DOUBLE TAP SCREEN TO FIRE YOUR SHIPS GUNS";

                tutImg1.sprite = _shipSprite;
                tutImg1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-55, 30);
                tutImg1.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg1.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100); // PRESERVED ASPECT RATIO

                tutImg2.sprite = _bulletSprite;
                tutImg2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-55, 124);
                tutImg2.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg2.GetComponent<RectTransform>().sizeDelta = new Vector2(12, 12);

                tutImg3.sprite = _handTapSprite;
                tutImg3.GetComponent<RectTransform>().anchoredPosition = new Vector2(74, 55);
                tutImg3.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg3.GetComponent<RectTransform>().sizeDelta = new Vector2(57.75f, 96); // PRESERVED ASPECT RATIO
                tutImg3.gameObject.SetActive(true);
                break;

            case 3:
                titleTxt.text = "OBSTACLES";
                instructionsTxt.text = "AVOID OBSTACLES TO INCREASE SCORE \nSHOOT AND DESTROY OBSTACLES TO MAXIMISE SCORE " +
                    "\nNOT ALL OBSTACLES CAN BE DESTROYED WITH GUN FIRE \nTHESE OBSTACLES CAN BE STALLED FOR A PERIOD OF TIME" +
                    " \nBE CAREFUL OF KINETIC ENERGY STORED IN THESE STALLED OBSTACLES";

                tutImg1.sprite = _satSprite;
                tutImg1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-65, 63);
                tutImg1.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 10);
                tutImg1.GetComponent<RectTransform>().sizeDelta = new Vector2(165.75f, 165.75f); // PRESERVED ASPECT RATIO

                tutImg2.sprite = _metalSprite;
                tutImg2.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 60);
                tutImg2.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg2.GetComponent<RectTransform>().sizeDelta = new Vector2(96, 34.125f); // PRESERVED ASPECT RATIO

                tutImg3.gameObject.SetActive(false);
                break;

            case 4:
                titleTxt.text = "POWER UPS";
                instructionsTxt.text = "COLLECT SHIP POWER UPS BY MOVING SHIP INTO THEM " +
                    "\nTHE LIGHT POWER UP WILL INCREASE YOUR SHIPS RATE OF FIRE " +
                    "\nTHE DARK POWER UP WILL INCREASE YOUR SHIPS MOVEMENT SPEED";

                tutImg1.sprite = _powerUpSprite;
                tutImg1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-60, 60);
                tutImg1.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg1.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60); // PRESERVED ASPECT RATIO

                tutImg2.sprite = _speedUpSprite;
                tutImg2.GetComponent<RectTransform>().anchoredPosition = new Vector2(60, 60);
                tutImg2.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
                tutImg2.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60); // PRESERVED ASPECT RATIO

                tutImg3.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }
}
