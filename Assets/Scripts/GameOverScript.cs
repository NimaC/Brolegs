using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	HealthScript oleghsscript;
	GameObject Oleg;

	void Awake ()
	{
		Oleg = GameObject.Find("Oleg");
		oleghsscript = Oleg.GetComponent<HealthScript>();
	}

    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

		if (oleghsscript.dieCount == 3) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 20), "Boleg Wins!");
		} else {
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "Oleg Wins!");
		}
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
            Application.LoadLevel("WoodenStage");
			Time.timeScale = 1.0f;
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
