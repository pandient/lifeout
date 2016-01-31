using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static readonly string[] bgm_tracks = {
        "Audio/tribal low chant loop (Scott F. Thompson).wav",
//		"Audio/bgm02",
//		"Audio/bgm03"
	};
	static MusicPlayer instance;

	static AudioSource audio_source;
	static AudioClip[] audio_clips;

	void Awake () {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
            instance = this;

            InitSoundtracks();
		}
	}

	void Start () {
        	//	StartCoroutine(PlayNextSong());
        audio_source.loop = true;
        audio_source.Play();
	}

    static void InitSoundtracks () {
		audio_source = instance.GetComponent<AudioSource>();
		audio_clips = new AudioClip[bgm_tracks.Length];
		for (var i = 0; i < bgm_tracks.Length; i++) {
			audio_clips[i] = Resources.Load<AudioClip>(bgm_tracks[i]);
		}
        Random.seed = System.Environment.TickCount;
	}

	IEnumerator PlayNextSong () {
		audio_source.clip = audio_clips[Random.Range(0, audio_clips.Length - 1)];
		audio_source.Play();

		yield return new WaitForSeconds(audio_source.clip.length);
		StartCoroutine(PlayNextSong());
	}

}
