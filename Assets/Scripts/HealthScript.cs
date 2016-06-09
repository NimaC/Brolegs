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
    private bool spawnShield = false;


    void Awake ()
    {
        anim = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Projectile" && dieCount < 2 && spawnShield == false) {
            anim.Play(dieState);
            StartCoroutine(Deathdelay());
        }
		else if (col.gameObject.tag == "Fire" && dieCount < 2 && spawnShield == false) {
			anim.Play(dieState);
			StartCoroutine(Deathdelay());
		}

		else if (col.gameObject.tag == "Fire" && dieCount == 2 && spawnShield == false) {
			Controller (false);
			anim.Play (dieState);
			transform.gameObject.AddComponent<GameOverScript> ();
			StartCoroutine (Freezedelay ());
		}
    

		else if (col.gameObject.tag == "Projectile" && dieCount == 2 && spawnShield == false) {
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
        spawnShield = true;
        yield return new WaitForSeconds(3.0f);
        spawnShield = false;
 
    }

	IEnumerator Freezedelay() {
		yield return new WaitForSeconds (.4f);
		Time.timeScale = 0.0f;
	}

	public void Controller (bool enable) {
		if (gameObject.name == "Oleg") {
			GetComponent<PlayerController> ().enabled = enable;
			GetComponentInChildren<AttackScript> ().enabled = enable;
		} 
		else if (gameObject.name == "Boleg") {
			Debug.Log ("BolegControls");
			GetComponent<BolegController> ().enabled = enable;
			// GetComponent<FireScript> ().enabled = enable;
		}
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
