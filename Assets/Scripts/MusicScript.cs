using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	AudioSource menumusic;
	static bool AudioBegin = false;

	void Start() {
		menumusic.loop = true;
	}

	void Awake()
	{
		menumusic = GetComponent<AudioSource>();

		if (AudioBegin && Application.loadedLevelName == "Menu") {
			Destroy (gameObject);
		}

		if (!AudioBegin) {
			menumusic.Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
		if(Application.loadedLevelName == "Green" || Application.loadedLevelName == "Purple" || Application.loadedLevelName == "Yellow")
		{
			menumusic.Stop();
			AudioBegin = false;
		}
	}
}