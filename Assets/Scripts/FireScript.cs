﻿using UnityEngine;
using System.Collections;
public class FireScript : MonoBehaviour {
	public Rigidbody2D Fire;

	private BolegController bolegCtrl;
	public string fireButton = "Fire_P1";
	public string refillButton = "Refill_P1";
	public static float fireTime = 2.5f;

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

		if (Input.GetButton(fireButton)){
			Vector3 tempPlace = new Vector3 (BolegController.positionX, BolegController.positionY, BolegController.positionZ);
			Vector3 tempScale = new Vector3 (BolegController.scaleX, BolegController.scaleY, BolegController.scaleZ);
			transform.localScale = tempScale;
		    transform.position = tempPlace;
		}
		if (Input.GetButton (refillButton) && fireTime < 2.5f && !Input.GetButton(fireButton)) {
            fireTime += (Time.deltaTime) / 2;
		}
	}

	/* IEnumerator Firedelay() {
		yield return new WaitForSeconds (3.0f);
		fireTime = 2.5f;
	} */
	}
}