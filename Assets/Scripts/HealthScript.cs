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

	private int numIcons = 3;
	private GameObject[] olegIcons;
	private GameObject[] bolegIcons;
	private Renderer[] olegiconrend;
	private Renderer[] bolegiconrend;
	int f = 0;

    void Awake ()
    {
        anim = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody2D>();

		olegIcons = new GameObject[numIcons];
		bolegIcons = new GameObject[numIcons];
		olegiconrend = new Renderer[numIcons];
		bolegiconrend = new Renderer[numIcons];

		for (int i = 0; i < numIcons; i++) {
			f++;
			olegIcons[i] = GameObject.Find(string.Concat("DeathIcon_Player1-", f.ToString()));
			bolegIcons[i] = GameObject.Find(string.Concat("DeathIcon_Player2-", f.ToString()));;
			olegiconrend[i] = olegIcons[i].GetComponent<Renderer>();
			bolegiconrend[i] = bolegIcons[i].GetComponent<Renderer>();
		}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Projectile" && dieCount < 2 && spawnShield == false && !ProjectileController.isStuck) {
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
		yield return new WaitForSeconds (1.5f);
		Controller (true);
		Vector3 temp = new Vector3(0,-7.5f,-4.3f);
		rBody.transform.position = temp;
		IconDisable ();
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
			GetComponent<BolegController> ().enabled = enable;
			// GetComponent<FireScript> ().enabled = enable;
		}
	}

	public void IconDisable() {
		if (gameObject.name == "Oleg") {
			olegiconrend [dieCount].enabled = false;
		} 

		else if (gameObject.name == "Boleg") {
			bolegiconrend [dieCount].enabled = false;
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
