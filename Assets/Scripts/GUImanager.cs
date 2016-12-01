using UnityEngine;
using System.Collections;

public class GUImanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play() {
		Application.LoadLevel ("LevelSelect");
	}

	public void Revanche() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Back() {
		Application.LoadLevel ("Menu");
	}

	public void Level1() {
		Application.LoadLevel("Yellow");
	}

	public void Level2() {
		Application.LoadLevel("Purple");
	}

	public void Level3() {
		Application.LoadLevel("Green");
	}

	public void Credits() {
		Application.LoadLevel("Credits");
	}
}
