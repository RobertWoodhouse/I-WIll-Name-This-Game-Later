using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text _scoreTxt;
    [SerializeField]
    private Button _backBtn;
    [SerializeField]
    private GameObject _mainMenu, _scoreWin;

    public static int Score = 0; // TODO when game starts set to 0

    private static List<int> _HighScores = new List<int>();


    private void Awake()
    {
        //PlayerPrefs.DeleteAll(); // TODO remove delete

        if (PlayerPrefsX.GetIntArray("HighScores") == null || PlayerPrefsX.GetIntArray("HighScores").Length < 10)
        {
            PlayerPrefsX.SetIntArray("HighScores", new int[] {12000, 10000, 9000, 8000, 7000, 6000, 5000, 4000, 3000, 2000}); // TODO switch order?
        }

        _HighScores = PlayerPrefsX.GetIntArray("HighScores").ToList<int>();
        //_HighScores.Reverse();
        //UpdateScoreArray();
        /*
        for(int i = 0; i < _HighScores.Count; i++) // TEST
        {
            print("Score " + (i + 1) + ": " + _HighScores[i]);
        }
        */
        /*
        for (int i = 0; i < PlayerPrefsX.GetIntArray("HighScores").Length; i++) // TEST
        {
            print("Score " + (i + 1) + ": " + PlayerPrefsX.GetIntArray("HighScores")[i]);
        }
        */
    }

    void Start()
    {
        if (_backBtn != null) _backBtn.onClick.AddListener(BackButtonOnClick);

        if (_scoreTxt != null) _scoreTxt.text = "1. " + PlayerPrefsX.GetIntArray("HighScores")[0] +
        "\n2. " + PlayerPrefsX.GetIntArray("HighScores")[1] + "\n3. " + PlayerPrefsX.GetIntArray("HighScores")[3] +
        "\n4. " + PlayerPrefsX.GetIntArray("HighScores")[3] + "\n5. " + PlayerPrefsX.GetIntArray("HighScores")[4] +
        "\n6. " + PlayerPrefsX.GetIntArray("HighScores")[5] + "\n7. " + PlayerPrefsX.GetIntArray("HighScores")[6] +
        "\n8. " + PlayerPrefsX.GetIntArray("HighScores")[7] + "\n9. " + PlayerPrefsX.GetIntArray("HighScores")[8] +
        "\n10. " + PlayerPrefsX.GetIntArray("HighScores")[9];
    }

    void BackButtonOnClick()
    {
        //gameObject.SetActive(false);
        _scoreWin.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    public static void SetHighScoreTable(int score)
    {
        /*
        if (score >= _HighScores[9])
        {
            for (int i = _HighScores.Count - 1; i >= 0; i--)
            //for (int i = 1; i < _HighScores.Count; i++)
            {
                if (score < _HighScores[i])
                {
                    print("Score added: " + score);
                    _HighScores.RemoveAt(9);
                    _HighScores.Insert(i, score);
                    //_HighScores.RemoveAt(9);
                    //_HighScores.Sort(); // TODO change to reverse?
                    //_HighScores.Reverse();
                    break;
                }
            }
            PlayerPrefsX.SetIntArray("HighScores", _HighScores.ToArray());
        }
        */

        if (score >= _HighScores[9] || score >= _HighScores[0]) // HACK Add score if higher than 9 or 0 then sort in ascending and reverse
        {
            _HighScores.Insert(9, score);
            _HighScores.Sort(); // Sort in ascending
            _HighScores.Reverse(); // Reverse sort
            _HighScores.RemoveAt(9);
            PlayerPrefsX.SetIntArray("HighScores", _HighScores.ToArray());
        }
    }
}
