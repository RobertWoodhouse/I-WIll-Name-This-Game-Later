using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public static void SceneSelect(string sceneName)
    {
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		AdMediaController.S.ResetAdBanner(); // TEST Reset Banner
	}

	public static IEnumerator SceneTransition(string sceneName, float time) // Update function only
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	public static void SceneQuit()
	{
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // DEBUG: Quit Editor
		#endif

		#if UNITY_ANDROID
        Application.Quit(); // PHONE: Quit Game
		#endif
    }
}
