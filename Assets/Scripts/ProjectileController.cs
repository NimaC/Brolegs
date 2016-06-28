using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {



    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Projectile" || col.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
