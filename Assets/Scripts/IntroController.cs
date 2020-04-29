using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
	public GameObject goLogo;

    [SerializeField]
	private float _fadeAlpha, _timer = 3.0f;

	void Start()
	{
		if (goLogo == null) goLogo = gameObject;
		StartCoroutine("VibrateLogo");
		StartCoroutine(SceneController.SceneTransition("01 - MainMenu", _timer));
	}

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
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(0f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(-1f, -6.0f, 0f);
		yield return new WaitForSeconds(.025f);
		goLogo.transform.GetChild(1).localPosition = new Vector3(0f, -5.0f, 0f);
		yield return new WaitForSeconds(.025f);
	}
}