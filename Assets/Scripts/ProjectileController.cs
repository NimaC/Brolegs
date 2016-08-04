using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private Rigidbody2D rBody;
	public static bool isStuck;
	public AudioSource[] sounds;
	AudioSource audio;

    void OnCollisionEnter2D (Collision2D col)
    {
		audio.Play ();
		if (col.gameObject.tag == "Player" && !isStuck || col.gameObject.tag == "Projectile" || col.gameObject.tag == "Fire") {
			StartCoroutine(playsound());
		}  else if (col.gameObject.tag == "Block") {
			isStuck = true;
			StartCoroutine(playsoundstuck());
		} 
		else if (col.gameObject.tag == "Border") {
			Destroy (gameObject);
		}
    }

	IEnumerator playsoundstuck() {
		audio.Play ();
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}

	IEnumerator playsound() {
		audio.Play ();
		yield return new WaitForSeconds (0.15f);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		sounds = GetComponents<AudioSource> ();
		audio = sounds [0];
		isStuck = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
