using UnityEngine;
using System.Collections;

public class CharacterselectMenu : MonoBehaviour {

	public int charindex;
	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		//Position des Buttons auf dem Bildschirm
		Rect olegRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			Screen.height / 4 - (buttonHeight /2),
			buttonWidth,
			buttonHeight
		);

		Rect bolegRect = new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(Screen.height / 4) * 2 - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		);

		//Button erstellen
		if (GUI.Button(olegRect, "Oleg"))
		{
			//erstes Level laden
			charindex = 0;
			Application.LoadLevel("BaseScene");
		}
	
		else if (GUI.Button(bolegRect, "Boleg"))
		{
		//erstes Level laden
		charindex = 1;
		Application.LoadLevel("BaseScene");
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
