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
    private GameObject _mainMenu;

    public static int Score = 0; // TODO when game starts set to 0

    private static List<int> _HighScores = new List<int>();


    private void Awake()
    {
        if (PlayerPrefsX.GetIntArray("HighScores") == null || PlayerPrefsX.GetIntArray("HighScores").Length < 10)
        {
            PlayerPrefsX.SetIntArray("HighScores", new int[] {10000, 9000, 8000, 7000, 6000, 5000, 4000, 3000, 2000, 1000});
        }

        _HighScores = PlayerPrefsX.GetIntArray("HighScores").ToList<int>();
        _HighScores.Sort();
        //UpdateScoreArray();
    }

    void Start()
    {
        if (_backBtn != null) _backBtn.onClick.AddListener(BackButtonOnClick);

        if (_scoreTxt != null) _scoreTxt.text = "1. " + PlayerPrefsX.GetIntArray("HighScores")[9] +
        "\n2. " + PlayerPrefsX.GetIntArray("HighScores")[8] + "\n3. " + PlayerPrefsX.GetIntArray("HighScores")[7] +
        "\n4. " + PlayerPrefsX.GetIntArray("HighScores")[6] + "\n5. " + PlayerPrefsX.GetIntArray("HighScores")[5] +
        "\n6. " + PlayerPrefsX.GetIntArray("HighScores")[4] + "\n7. " + PlayerPrefsX.GetIntArray("HighScores")[3] +
        "\n8. " + PlayerPrefsX.GetIntArray("HighScores")[2] + "\n9. " + PlayerPrefsX.GetIntArray("HighScores")[1] +
        "\n10. " + PlayerPrefsX.GetIntArray("HighScores")[0];
    }

    void BackButtonOnClick()
    {
        gameObject.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    public static void SetHighScoreTable(int score)
    {
        if (score > _HighScores[0])
        {
            //for (int i = 8; i >= 0; i--)
            for (int i = 1; i < _HighScores.Count - 1; i++)
            {
                if (score < _HighScores[i])
                {
                    print("Score added: " + score);
                    _HighScores.Insert(i, score);
                    _HighScores.RemoveAt(0);
                    _HighScores.Sort();
                    break;
                }
            }
            PlayerPrefsX.SetIntArray("HighScores", _HighScores.ToArray());
        }
    }
}
