using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public AudioClip clipExplosion;

    [SerializeField]
    private float _destroyTime = 0.5f;
    private Animator _animShip;
    private bool _isCollide = false;

    //private static int _AdCounter = 4;

    private void Start()
    {
        _animShip = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("StarterObstacles"))
        {
            if (!_isCollide) // HACK prevent double collision
            {
                _isCollide = true;
                GameEvents.S.PlaySFX(clipExplosion, AudioController.SoundEffects.Sound);
                StartCoroutine(DestroyObject(_destroyTime));
                ScoreController.SetHighScoreTable(ScoreController.Score); // Set HighScore
                GUIController.S.LoadGameOverPanel(ScoreController.Score);
                AdMediaController.S.AdCounter();
                //AdCounter();
                if (SelectShipController.IsShip3Locked) Unlockable.UnlockThroughScore(); // TODO Test if true then unlock
                StartCoroutine(PauseController.PauseAndPlay(PauseController.PlaySpeed.SlowMotion));
            }
        }
    }

    IEnumerator DestroyObject(float time) // Destroys shop after elapsed time
    {
        print("Destroy player and animate explosion");
        _animShip.SetTrigger("ShipExplode");
        Destroy(gameObject.transform.GetChild(0).gameObject); // HACK destroy Afterburner child GO to stop animator 
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    /*
    private void AdCounter()
    {
        if (_AdCounter <= 0)
        {
            AdMediaController.S.ShowAdVideo();
            _AdCounter = 4;
        }
        else if (_AdCounter > 3)
        {
            _AdCounter--;
        }
        else
        {
            AdMediaController.S.ShowAdBanner(true);
            _AdCounter--;
        }
        print("Ad counter = " + _AdCounter);
    }
    */
}
