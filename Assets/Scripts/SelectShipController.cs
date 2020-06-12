using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectShipController : MonoBehaviour
{
    public Text nameTxt, descriptionTxt;
    public Image shipImg;
    public AudioClip[] clipSelectSFX;
    public static bool IsShip2Unlocked = false, IsShip3Unlocked = false;
    public static int SelectedShip = 0;

    //[SerializeField]
    //private Text _headerTxt; // TODO change to single static var
    [SerializeField]
    private Sprite[] _shipSprites;
    [SerializeField]
    private Sprite _shipLockedSprite;
    [SerializeField]
    private Button _leftBtn, _rightBtn, _backBtn, _selectBtn, _adBtn;
    [SerializeField]
    private GameObject _mainMenu, _selectShipWin;
    public int _selectNum = 0;
    private string[] _names = { "SIR LENWORTH", "S.S. BUC NASTY", "BANTON CHRONICLE" };
    private string[] _descriptions =
    {
        "SIR LENWORTH IS INTELLIGENT, ARTICULATE, WITTY AND FAST \nWITH UNPARALLELED SPEEDS NOT SEEN SINCE THE 1992 OLYMPIC GAMES \nYOU DON'T WANNA SEE WHAT'S PACKED IN THIS SHIPS LUNCHBOX"

        ,"THE S.S. BUC NASTY BOASTS SUPERIOR FIRE POWER \nTHEY SAY THE SKY IS COVERED IN DARKNESS WHEN THIS SHIP RAINS GUNFIRE \nSOMETIMES THE SHIP WILL SPIT A RHYME TO SPREAD FEAR IN A MANS HEART \n\"MY NAME IS BUC, WHEN I SHOOT YOU BEST DUCK!\""

        ,"THE BANTON CHRONICLE IS A COMPENDIUM OF KNOWLEDGE \nWITH WISDOM PASSED DOWN FROM GENERATIONS OF GRIOTS \nTHIS KNOWLEDGE HAS MANIFESTED IN A SHIP WHICH EXCELS IN BOTH SPEED AND POWER \nWHEN FACED AGAINST INSURMOUNTABLE ODDS A WISE POET FROM INGLEWOOD ONCE SAID \"THE ONLY WAY YOU BEAT US IS CHEAT US\" \nLIKE BRER ANANSI \"BANTON CHRONICLE A GINNAL, IF HIM AFFI TRICK PEOPLE FI GET DI UPPER HAND HIM WILL\""
    };


    private void Awake()
    {
        //PlayerPrefs.DeleteAll(); // TODO remove delete
        IsShip2Unlocked = PlayerPrefsX.GetBool("Ship2Locked");
        IsShip3Unlocked = PlayerPrefsX.GetBool("Ship3Locked");
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
        //gameObject.SetActive(false);
        _selectShipWin.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }


    void AdButtonOnClick()
    {
        /*
        nameTxt.text = _names[1];
        descriptionTxt.text = _descriptions[1];
        shipImg.sprite = _shipSprites[1];
        _selectBtn.interactable = true;
        _adBtn.gameObject.SetActive(false);
        */
        StartCoroutine(ResetShipSelection());
        //AdMediaController.S.ShowAdRewardedVideo();
    }

    void SelectButtonOnClick() 
    {
        SelectedShip = _selectNum;
        GameEvents.S.PlaySFX(clipSelectSFX[_selectNum], AudioController.SoundEffects.Menu);
    }

    IEnumerator ResetShipSelection()
    {
        AdMediaController.S.ShowAdRewardedVideo();
        yield return new WaitForSeconds(0.25f);
        nameTxt.text = _names[1];
        descriptionTxt.text = _descriptions[1];
        shipImg.sprite = _shipSprites[1];
        _selectBtn.interactable = true;
        _adBtn.gameObject.SetActive(false);
    }

    void SelectShip(int select)
    {
        if (!IsShip2Unlocked && select == 1)
        {
            nameTxt.text = "???";
            descriptionTxt.text = "PLAY AD VIDEO TO UNLOCK SHIP";
            shipImg.sprite = _shipLockedSprite;
            _adBtn.gameObject.SetActive(true);
            _selectBtn.interactable = false;
        }
        else if (!IsShip3Unlocked && select == 2)
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
