using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {
	HealthScript oleghsscript;
	Animator gameOveranim;
	GameObject Oleg;
	GameObject Boleg;
	GameObject gameOver;
	GameObject canvasobj;
	GameObject Throw;
	GameObject back;
	GameObject revanche;
	public Canvas[] canvas;

	void Awake ()
	{
		Oleg = GameObject.Find("Oleg");
		Boleg = GameObject.Find ("Boleg");
		gameOver = GameObject.Find("GameOver");
		Throw = GameObject.Find ("Throw");
		back = GameObject.Find ("Back");
		revanche = GameObject.Find ("Revanche");
		oleghsscript = Oleg.GetComponent<HealthScript>();
		gameOveranim = gameOver.GetComponent<Animator> ();
		canvasobj = GameObject.Find ("Overlay");
		canvas = canvasobj.GetComponents<Canvas> ();
	}

    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

		if (oleghsscript.dieCount == 3) {
			gameOveranim.SetTrigger ("BolegVictory");
		} else {
			gameOveranim.SetTrigger ("OlegVictory");
		}
		back.GetComponent<Button>().enabled = true;
		revanche.GetComponent<Button>().enabled = true;
		canvas[0].enabled = true;
		Oleg.GetComponent<PlayerController> ().enabled = false;
		Throw.GetComponent<AttackScript> ().enabled = false;
		Boleg.GetComponent<BolegController> ().enabled = false;
    }

}
