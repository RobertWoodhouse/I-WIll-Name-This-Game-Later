using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text _scoreTxt;
    [SerializeField]
    private Button _backBtn;
    [SerializeField]
    private GameObject _mainMenu;

    void Start()
    {
        _backBtn.onClick.AddListener(BackButtonOnClick);
        //TEST
        _scoreTxt.text = "1. 50000 \n2. 40000  \n3. 30000 \n4. 20000 \n5. 10000 \n6. 9000 \n7. 8000 \n8. 7000 \n9. 7000 \n10. 6000";
    }

    void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }
}
