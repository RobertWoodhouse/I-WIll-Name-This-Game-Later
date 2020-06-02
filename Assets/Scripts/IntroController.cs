using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
	public GameObject goLogo;
	public Camera cam;

    [SerializeField]
	private float _timer = 3.0f;
	private Color32[] _colours32 = { new Color32(248, 9, 26, 255), new Color32(254, 253, 51, 255), new Color32(34, 152, 20, 255) };

	void Start()
	{
		if (goLogo == null) goLogo = gameObject;
		cam.backgroundColor = _colours32[Random.Range(0, 3)]; // RED(0) / YELLOW (1) / GREEN (2)
		StartCoroutine("VibrateLogo");
		StartCoroutine(SceneController.SceneTransition("01 - MainMenu", _timer));
	}

    IEnumerator VibrateLogo()
    {
		// POSITION SPEAKERS AND SOUNDWAVES
		goLogo.transform.GetChild(1).localScale = new Vector3(7.5f, 3.5f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-9.5f, 5.5f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10f, 5.5f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-9.5f, 0.5f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(9.5f, 0.5f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.05f);

		goLogo.transform.GetChild(1).localScale = new Vector3(8f, 4f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-10f, 6.0f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10.5f, 6.0f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-10f, 0f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(10f, 0f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(7.5f, 3.5f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-9.5f, 5.5f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10f, 5.5f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-9.5f, 0.5f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(9.5f, 0.5f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(8f, 4f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-10f, 6.0f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10.5f, 6.0f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-10f, 0f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(10f, 0f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(7.5f, 3.5f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-9.5f, 5.5f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10f, 5.5f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-9.5f, 0.5f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(9.5f, 0.5f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(8f, 4f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-10f, 6.0f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10.5f, 6.0f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-10f, 0f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(10f, 0f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(7.5f, 3.5f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-9.5f, 5.5f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10f, 5.5f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-9.5f, 0.5f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(9.5f, 0.5f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(8f, 4f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-10f, 6.0f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10.5f, 6.0f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-10f, 0f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(10f, 0f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(7.5f, 3.5f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-9.5f, 5.5f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10f, 5.5f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-9.5f, 0.5f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(9.5f, 0.5f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		goLogo.transform.GetChild(1).localScale = new Vector3(8f, 4f, 1f);
		goLogo.transform.GetChild(2).localPosition = new Vector3(-10f, 6.0f, 0f); // TOP-LEFT
		goLogo.transform.GetChild(3).localPosition = new Vector3(10.5f, 6.0f, 0f); // TOP-RIGHT
		goLogo.transform.GetChild(4).localPosition = new Vector3(-10f, 0f, 0f); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localPosition = new Vector3(10f, 0f, 0f); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.1f);

		// ROTATE SOUNDWAVES
		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f); 

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f); 

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f); 

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, -20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);
		
		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);
		
		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);
		
		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f); // 5
		/*
		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, -20); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 20); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, -20); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 20); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);

		goLogo.transform.GetChild(2).localRotation = Quaternion.Euler(0, 0, 0); // TOP-LEFT
		goLogo.transform.GetChild(3).localRotation = Quaternion.Euler(0, 0, 0); // TOP-RIGHT
		goLogo.transform.GetChild(4).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-LEFT
		goLogo.transform.GetChild(5).localRotation = Quaternion.Euler(0, 0, 0); // BOTTOM-RIGHT
		yield return new WaitForSeconds(.025f);
		*/
	}
}