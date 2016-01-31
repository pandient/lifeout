using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	static int current_level;

	public static void LoadLevel (string sceneName) {
		if (sceneName == "Level_01") {
			current_level = 1;
		}
		SceneManager.LoadScene(sceneName);
	}

    public void LoadLevelWrapper(string sceneName)
    {
        LoadLevel(sceneName);
    }

	public static void ReloadCurrentLevel () {
        SceneManager.LoadScene(current_level);
	}

    public void ReloadCurrentLevelWrapper()
    {
        ReloadCurrentLevel();
    }

	public static void LoadNextLevel () {
        current_level += 1;
		//current_level = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(current_level);
	}

    public void LoadNextLevelWrapper()
    {
        LoadNextLevel();
    }

	public static void QuitGame () {
		Application.Quit();
	}

    public void QuitGameWrapper()
    {
        QuitGame();
    }

}
