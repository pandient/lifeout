using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	static int current_level;

	public void LoadLevel (string sceneName) {
		if (sceneName == "Level_01") {
			current_level = 1;
		}
		SceneManager.LoadScene(sceneName);
	}

	public void ReloadCurrentLevel () {
        SceneManager.LoadScene(current_level);
	}

	public void LoadNextLevel () {
		current_level = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(current_level);
	}

	public void QuitGame () {
		Application.Quit();
	}

}
