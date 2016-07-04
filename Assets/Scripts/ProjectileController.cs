using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private Rigidbody2D rBody;
	public static bool isStuck = false;

    void OnCollisionEnter2D (Collision2D col)
    {
		if (col.gameObject.tag == "Player" && !isStuck || col.gameObject.tag == "Projectile" || col.gameObject.tag == "Fire" || col.gameObject.tag == "Border") {
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Block") {
			isStuck = true;
		}
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
