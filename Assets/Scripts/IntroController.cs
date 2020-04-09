using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
	//public float timer = 4.0f, fadeTimer = 3.0f, fadeRed = 255, fadeBlue = 255, fadeGreen = 255;
	public GameObject goLogo;

    [SerializeField]
	private float _fadeAlpha;
	//private Image _logo;
	private Color _fadeColor;

	void Start()
	{
		if (goLogo == null) goLogo = gameObject;
		//StartCoroutine(SceneController.SceneTransition("-001_Test_Scene", timer));
		//_logo = go.GetComponent<Image>();
		StartCoroutine("VibrateLogo");
		//GameEvents.S.onPlaySFX();
	}

	// Update is called once per frame
	void Update()
	{
		//LoadIntro();
		//FadeLogo();
	}
    /*
	void LoadIntro() // FIX Logo fade
	{
		fadeTimer -= Time.deltaTime;

		if (fadeTimer < 0.25)
		{
			Debug.Log("Fade logo");
			_fadeColor = new Color(fadeRed, fadeGreen, fadeBlue);
			//_logo.color = Color.Lerp(_fadeColor, Color.yellow, Mathf.PingPong(Time.time, 3));
		}
	}
    */
    
    // TODO CHANGE TO FADE COLOUR
	void FadeLogo()
	{
		_fadeAlpha -= Time.deltaTime;

		goLogo.GetComponentsInChildren<SpriteRenderer>()[0].color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));
		goLogo.GetComponentsInChildren<SpriteRenderer>()[1].color = new Color32(255, 255, 255, (byte)(_fadeAlpha * 105));

	}

    IEnumerator VibrateLogo()
    {
		goLogo.transform.GetChild(1).localScale = new Vector3(1.7f, 1f, 1f);
		yield return new WaitForSeconds(.05f);
		goLogo.transform.GetChild(1).localScale = new Vector3(2f, 1.3f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(1.7f, 1f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(2f, 1.3f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(1.7f, 1f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(2f, 1.3f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(1.7f, 1f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localScale = new Vector3(2f, 1.3f, 1f);
		yield return new WaitForSeconds(.1f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(0f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
	}

}
