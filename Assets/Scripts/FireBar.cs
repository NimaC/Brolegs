﻿using UnityEngine;
using System.Collections;

public class FireBar : MonoBehaviour {

	private BolegController bolegCtrl;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Awake() {
	}

	// Update is called once per frame
	void Update () {
		anim.SetFloat("FireBlend", FireScript.fireTime);
	}
}
