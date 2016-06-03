using UnityEngine;
using System.Collections;
//using Prime31;

public class HealthScript : MonoBehaviour {

    //private CharacterController2D playerCtrl;
    private Collider2D projectile;
    Animator anim;
	private int dieCount = 0;
    private int dieState = Animator.StringToHash("Base Layer.Die");
	private Rigidbody2D rBody;

    void Awake ()
    {
        anim = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile" && dieCount < 3) {
			anim.Play (dieState);
			StartCoroutine (Deathdelay());
		}

		else if (col.gameObject.tag == "Projectile" && dieCount == 3) {
			Controller (false);
			anim.Play (dieState);
			transform.gameObject.AddComponent<GameOverScript> ();
			StartCoroutine (Freezedelay ());
		}
    }
    
	IEnumerator Deathdelay() {
		Controller (false);
		yield return new WaitForSeconds (.5f);
		Controller (true);
		Vector3 temp = new Vector3(0,-7.5f,-4.3f);
		rBody.transform.position = temp;
		dieCount = dieCount + 1;
	}

	IEnumerator Freezedelay() {
		yield return new WaitForSeconds (.4f);
		Time.timeScale = 0.0f;
	}

	void Controller (bool enable) {
		GetComponent<PlayerController> ().enabled = enable;
		GetComponentInChildren<AttackScript> ().enabled = enable;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       /* if(projectile != null && projectile.gameObject.tag== "Projectile")
        {
            playerCtrl.OnTriggerEnter2D(projectile);
            Destroy(gameObject);
        }

      */  
	
	}
}
