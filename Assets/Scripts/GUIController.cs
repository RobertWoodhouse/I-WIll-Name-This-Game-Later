using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public AudioClip[] clipHighScoreSFX, clipTopTenSFX, clipGameOverSFX, clipGameOverLoserSFX;

    [SerializeField]
    private Button _playBtn, _pauseBtn;
    [SerializeField]
    private Text _scoreTxt, _levelTxt;
    [SerializeField]
    private GameObject _pauseMenu, _gameOverPanel, _guiPanel;
    private Image _guiImage;
    private string[] _gameOverMessages, _gameOverLoserMessages;

    public static GUIController S;

    private void Awake()
    {
        SelectShipController.IsShip2Unlocked = PlayerPrefsX.GetBool("Ship2Locked");
        SelectShipController.IsShip3Unlocked = PlayerPrefsX.GetBool("Ship3Locked");
    }

    void Start()
    {
        _guiImage = _guiPanel.GetComponent<Image>();
        _gameOverMessages = new string[] { "A GEM CANNOT BE POLISHED WITHOUT FRICTION, NOR A MAN PERFECTED WITHOUT TRIALS", "WITHIN EVERY OBSTACLE IS AN OPPORTUNITY TO IMPROVE YOUR CONDITION", "WHAT IS DEFEAT? NOTHING BUT THE FIRST STEPS TO SOMETHING BETTER", "WINNERS NEVER QUIT, QUITTERS NEVER WIN", "SOMETIMES LIFE HITS YOU ON THE HEAD WITH A BRICK. DON'T LOSE FAITH", "YOU HAVE POWER OVER YOUR MIND, NOT OUTSIDE EVENTS. REALIZE THIS AND YOU WILL FIND STRENGTH", "DISCOMFORT IS THE CURRENCY OF SUCCESS", "IF IT DOESN'T CHALLENGE YOU, IT WON'T CHANGE YOU", "MAKE THE MIND TOUGHER BY EXPOSING IT TO ADVERSITY", "A MAN IS NO BIGGER THAN THE SMALLEST THING THAT PROVOKES HIM", "LEARN TO DETACH YOURSELF FROM THE CHAOS OF THE BATTLEFIELD", "GROWTH AND COMFORT DO NOT COEXIST" };
        _gameOverLoserMessages = new string[] { "DAT NUH LOOK GOOD...", "NAH FAM, YOU'RE HAVING A LAUGH", "IS THAT IT?!" , "WEAK!...", "THIS A JOKE TING", "REALLY?", "NAH... THAT AIN'T IT"};
        S = this;
        _pauseBtn.onClick.AddListener(PauseButtonOnClick);
    }

    void Update()
    {
        _scoreTxt.text = "SCORE: " + ScoreController.Score;
        _levelTxt.text = "LEVEL: " + GameController.GameLevel;
    }

    void PauseButtonOnClick()
    {
        StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.Pause));
        _pauseMenu.SetActive(true);
        _playBtn.gameObject.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        _guiImage.color = new Color(_guiImage.color.r, _guiImage.color.g, _guiImage.color.b, 1f);
    }

    public void LoadGameOverPanel(int score)
    {
        _gameOverPanel.SetActive(true);
        _pauseBtn.gameObject.SetActive(false);
        _guiPanel.SetActive(false);
        int rand = Random.Range(0, _gameOverMessages.Length - 1);
        int randLose = Random.Range(0, _gameOverLoserMessages.Length - 1);

        if (score > PlayerPrefsX.GetIntArray("HighScores")[0])
        {
            GameOverController.S.UpdateGameOverScreen("NEW HIGH SCORE!", score.ToString());
            GameEvents.S.PlaySFX(clipHighScoreSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else if (score >= PlayerPrefsX.GetIntArray("HighScores")[9] && score <= PlayerPrefsX.GetIntArray("HighScores")[0])
        {
            GameOverController.S.UpdateGameOverScreen("YOU CRACKED THE TOP 10", score.ToString());
            GameEvents.S.PlaySFX(clipTopTenSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else if (score > 2000 && score < PlayerPrefsX.GetIntArray("HighScores")[9])
        {
            GameOverController.S.UpdateGameOverScreen("GAME OVER", _gameOverMessages[rand]);
            GameEvents.S.PlaySFX(clipGameOverSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
        else
        {
            GameOverController.S.UpdateGameOverScreen("GAME OVER", _gameOverLoserMessages[randLose]);
            GameEvents.S.PlaySFX(clipGameOverLoserSFX[SelectShipController.SelectedShip], AudioController.SoundEffects.Menu);
        }
    }
}
