using System.Collections;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    public AudioClip clipExplosion;

    [SerializeField]
    private float _destroyTime = 0.5f;
    private Animator _animShip;
    private bool _isCollide = false;

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
                GUIController.S.LoadGameOverPanel(ScoreController.Score);
                ScoreController.SetHighScoreTable(ScoreController.Score); // Set HighScore
                print("Is Ship 3 unlocked?" + SelectShipController.IsShip3Unlocked);
                AdMediaController.S.AdCounter();
                if (!SelectShipController.IsShip3Unlocked) Unlockable.UnlockThroughScore();
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
}
