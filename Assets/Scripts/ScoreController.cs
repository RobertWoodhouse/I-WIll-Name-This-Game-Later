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

    public static int Score = 0;

    private static List<int> _HighScores = new List<int>();


    private void Awake()
    {

        if (PlayerPrefsX.GetIntArray("HighScores") == null || PlayerPrefsX.GetIntArray("HighScores").Length < 10)
        {
            PlayerPrefsX.SetIntArray("HighScores", new int[] {30000, 28000, 26000, 24000, 22000, 20000, 18000, 16000, 14000, 12000});
        }

        _HighScores = PlayerPrefsX.GetIntArray("HighScores").ToList<int>();
    }

    void Start()
    {
        if (_backBtn != null) _backBtn.onClick.AddListener(BackButtonOnClick);

        if (_scoreTxt != null) _scoreTxt.text = "1. " + PlayerPrefsX.GetIntArray("HighScores")[0] +
        "\n2. " + PlayerPrefsX.GetIntArray("HighScores")[1] + "\n3. " + PlayerPrefsX.GetIntArray("HighScores")[2] +
        "\n4. " + PlayerPrefsX.GetIntArray("HighScores")[3] + "\n5. " + PlayerPrefsX.GetIntArray("HighScores")[4] +
        "\n6. " + PlayerPrefsX.GetIntArray("HighScores")[5] + "\n7. " + PlayerPrefsX.GetIntArray("HighScores")[6] +
        "\n8. " + PlayerPrefsX.GetIntArray("HighScores")[7] + "\n9. " + PlayerPrefsX.GetIntArray("HighScores")[8] +
        "\n10. " + PlayerPrefsX.GetIntArray("HighScores")[9];
    }

    void BackButtonOnClick()
    {
        _scoreWin.SetActive(false);
        _mainMenu.SetActive(true);
        _backBtn.gameObject.SetActive(false);
        MainMenuController.S.SetHeaderText("I'LL NAME THIS GAME LATER");
    }

    public static void SetHighScoreTable(int score)
    {
        if (score >= _HighScores[_HighScores.Count - 1] || score >= _HighScores[0]) // HACK Add score if higher than 9 
        {
            _HighScores.Insert(_HighScores.Count - 1, score);
            _HighScores.Sort(); // Sort in ascending
            _HighScores.Reverse(); // Reverse sort
            _HighScores.RemoveAt(_HighScores.Count - 1);
            PlayerPrefsX.SetIntArray("HighScores", _HighScores.ToArray());
        }
    }
}
