using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private Rigidbody2D rBody;
	public static bool isStuck = false;
	public AudioSource[] sounds;
	AudioSource audio;

    void OnCollisionEnter2D (Collision2D col)
    {
		audio.Play ();
		if (col.gameObject.tag == "Player" && !isStuck || col.gameObject.tag == "Projectile" || col.gameObject.tag == "Fire" || col.gameObject.tag == "Block") {
			StartCoroutine(playsound());
		}  /*else if (col.gameObject.tag == "Block") {
			isStuck = true;
		} */
		else if (col.gameObject.tag == "Border") {
			Destroy (gameObject);
		}
    }

	IEnumerator playsound() {
		audio.Play ();
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
		sounds = GetComponents<AudioSource> ();
		audio = sounds [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
