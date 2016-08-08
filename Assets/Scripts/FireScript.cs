using UnityEngine;
using System.Collections;
public class FireScript : MonoBehaviour {
	public Rigidbody2D Fire;

	private BolegController bolegCtrl;
	public string fireButton = "Fire_P2";
	public string refillButton = "Refill_P1";
	public static float fireTime = 2.5f;
	public AudioClip fire;
	public AudioClip refill;
	//Sounds
	public AudioSource[] sounds;
	AudioSource audio;

	// Use this for initialization
	void Start () {
	}

	void Awake ()
	{
		bolegCtrl = transform.root.GetComponent<BolegController>();
	}

	// Update is called once per frame
	void Update () {
		if (fireTime > 0) {
			if (Input.GetButton (fireButton)) {
				Vector3 tempPlace = new Vector3 (BolegController.positionX, BolegController.positionY, BolegController.positionZ);
				Vector3 tempScale = new Vector3 (BolegController.scaleX, BolegController.scaleY, BolegController.scaleZ);
				transform.localScale = tempScale;
				transform.position = tempPlace;
				fireTime -= Time.deltaTime;
			} else {
				transform.position = new Vector3 (100, 100, 100);
			}
			  
		}

		else {
			transform.position = new Vector3 (100, 100, 100);
			//StartCoroutine (Firedelay ());

			//		if (Input.GetButton(fireButton)){
			//			Vector3 tempPlace = new Vector3 (BolegController.positionX, BolegController.positionY, BolegController.positionZ);
			//			Vector3 tempScale = new Vector3 (BolegController.scaleX, BolegController.scaleY, BolegController.scaleZ);
			//			transform.localScale = tempScale;
			//		    transform.position = tempPlace;
			//		}
		}
		if (Input.GetButton (refillButton) && fireTime < 2.5f && !Input.GetButton (fireButton)) {
			fireTime += (Time.deltaTime) / 2;
			BolegController.refill = true;
		} else {
			BolegController.refill = false;
			// audio.Stop();
		}

		// Sounds 
		if (Input.GetButtonDown (fireButton) && fireTime > 0) {
				audio = GetComponent<AudioSource> ();
				audio.PlayOneShot (fire);
			}  
		
		else if (Input.GetButtonUp(fireButton)) {
			audio = GetComponent<AudioSource> ();
			audio.Stop ();
		} 

		if (Input.GetButtonDown(refillButton) && fireTime < 2.5f && !Input.GetButton (fireButton)) {
			audio = GetComponent<AudioSource> ();
			audio.PlayOneShot (refill);
		} 
		else if (Input.GetButtonUp(refillButton)) {
			audio = GetComponent<AudioSource> ();
			audio.Stop ();
		}
		/* IEnumerator Firedelay() {
		yield return new WaitForSeconds (3.0f);
		fireTime = 2.5f;
	} */
	}
}