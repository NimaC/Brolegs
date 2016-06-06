﻿using UnityEngine;
using System.Collections;



public class GameOverScript : MonoBehaviour {
	public HealthScript healthscript;

    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        //Position der zwei Buttons
        if (
            GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (1 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
            ),
            "Play Again"
            )
        )
        {
            // Reload the level
            Application.LoadLevel("BaseScene");
			Time.timeScale = 1.0f;
			healthscript.Controller (true);
        }

        if (
             GUI.Button(
             new Rect(
                 Screen.width / 2 - (buttonWidth / 2),
                 (2 * Screen.height / 3) - (buttonHeight / 2),
                 buttonWidth,
                 buttonHeight
             ),
             "Back to menu"
             )
        )
        {
            // Reload the level
            Application.LoadLevel("Menu");
        }
    }

}
