using UnityEngine;
using System.Collections;

public class FireBar : MonoBehaviour {

	private BolegController bolegCtrl;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Awake() {
		bolegCtrl = transform.root.GetComponent<BolegController>();
	}

	// Update is called once per frame
	void Update () {
		anim.SetFloat("FireBlend", FireScript.fireTime);
	}
	void FixedUpdate() {
		Vector3 tempPlace = new Vector3 (BolegController.positionX, BolegController.positionY + 2.0f, BolegController.positionZ);
		transform.position = tempPlace;
	}
}
