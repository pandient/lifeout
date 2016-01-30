using UnityEngine;

public class Background : MonoBehaviour {

	static readonly string[] backgrounds = {
//		"Backgrounds/background01",
//		"Backgrounds/background02",
//		"Backgrounds/background03",
	};
	static int current_bg_index = -1;

	public bool ResetOnLoad;

	void Start () {
		if (ResetOnLoad || current_bg_index < 0) {
			current_bg_index = Random.Range(0, backgrounds.Length - 1);
		}
//		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(backgrounds[current_bg_index]);
	}
	
}
