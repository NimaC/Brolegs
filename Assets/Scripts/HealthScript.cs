using UnityEngine;
using System.Collections;
//using Prime31;

public class HealthScript : MonoBehaviour {

    //private CharacterController2D playerCtrl;
    private Collider2D projectile;
    Animator anim;
	public int dieCount = 0;
    // private int dieState = Animator.StringToHash("Base Layer.Die");
	private Rigidbody2D rBody;
    private bool spawnShield = false;

	private GameObject olegupper;
	private GameObject oleglower;
	private GameObject boleg;

	private SpriteRenderer olegupperRend;
	private SpriteRenderer oleglowerRend;
	private SpriteRenderer bolegRend;

	private Material shiny;
	private Material norm;

	public AudioSource[] sounds;
	AudioSource audio;
	AudioSource olegdeadsound;
	public AudioClip OlegDies;

	private int numIcons = 3;
	private GameObject[] olegIcons;
	private GameObject[] bolegIcons;
	private GameObject[] bolegsplashIcons;
	private GameObject[] olegsplashIcons;
	private Renderer[] olegiconrend;
	private Renderer[] bolegiconrend;
	private Renderer[] bolegsplashiconrend;
	private Renderer[] olegsplashiconrend;
	int f = 0;

	void chooseRndHitSnd()
	{
		int numb = (int) Random.Range (2f, 5f);
		audio = sounds [numb];
	}

    void Awake ()
    {
		olegupper = GameObject.Find("upperBody");
		oleglower = GameObject.Find("lowerBody");
		boleg = GameObject.Find ("Boleg");
		olegupperRend = olegupper.GetComponent<SpriteRenderer> ();
		oleglowerRend = oleglower.GetComponent<SpriteRenderer> ();
		bolegRend = boleg.GetComponent<SpriteRenderer> ();
		shiny = Resources.Load("Materials/ShinyDefault", typeof(Material)) as Material;
		norm = boleg.GetComponent<SpriteRenderer> ().material;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		 {
			if (col.gameObject.tag == "Projectile" && spawnShield == false && !ProjectileController.isStuck && gameObject.name != "Oleg") {
				spawnShield = true;
				chooseRndHitSnd ();
				audio.Play ();
				// anim.Play(dieState);
				if (dieCount < 2) {
					StartCoroutine (Deathdelay ());
				} else {
					Controller (false);
					StartCoroutine (Freezedelay ());
				}

			} else if (col.gameObject.tag == "Fire" && spawnShield == false && gameObject.name != "Boleg") {
				spawnShield = true;
				AudioSource olegdie = GetComponent<AudioSource> ();
				olegdie.PlayOneShot (OlegDies);
				// anim.Play(dieState);
				if (dieCount < 2) {
					StartCoroutine (Deathdelay ());
				} else {
					Controller (false);
					StartCoroutine (Freezedelay ());
				}
			}
		}
    }
		
    
	IEnumerator Deathdelay() {
		IconDisable ();
		dieCount = dieCount + 1;
		anim.SetBool("Dead", true);
		Controller (false);
		yield return new WaitForSeconds (1.5f);
		Controller (true);
		Vector3 temp = new Vector3(0,-7.5f,-4.3f);
		rBody.transform.position = temp;
		SpawnGlowOn ();
		anim.SetBool("Dead", false);
        yield return new WaitForSeconds(3.0f);
        spawnShield = false;
		SpawnGlowOff ();
    }

	void bolegsplashiconhandler(int diecnt) {
		if (diecnt == 0) {
			bolegsplashiconrend[2].enabled = false;
			bolegsplashiconrend[1].enabled = false;
			bolegsplashiconrend[0].enabled = true;
		} else if (diecnt == 1) {
			bolegsplashiconrend[2].enabled = true;
			bolegsplashiconrend[1].enabled = false;
			bolegsplashiconrend[0].enabled = false;
		}
		else if (diecnt == 2) {
			bolegsplashiconrend[2].enabled = false;
			bolegsplashiconrend[1].enabled = true;
			bolegsplashiconrend[0].enabled = false;
		}
	}

	void olegsplashiconhandler(int diecnt) {
		if (diecnt == 0) {
			olegsplashiconrend [2].enabled = false;
			olegsplashiconrend [1].enabled = false;
			olegsplashiconrend [0].enabled = true;
		} else if (diecnt == 1) {
			olegsplashiconrend [2].enabled = false;
			olegsplashiconrend [1].enabled = true;
			olegsplashiconrend [0].enabled = false;
		} else if (diecnt == 2) {
			olegsplashiconrend [2].enabled = true;
			olegsplashiconrend [1].enabled = false;
			olegsplashiconrend [0].enabled = false;
		}
	}

	IEnumerator Freezedelay() {
		IconDisable ();
		dieCount = dieCount + 1;
		anim.SetBool("Dead", true);
		yield return new WaitForSeconds (1f);
		//Time.timeScale = 0.0f;
		transform.gameObject.AddComponent<GameOverScript> ();
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

	public void SpawnGlowOn() {
		if (gameObject.name == "Oleg") {
			olegupperRend.material = shiny;
			oleglowerRend.material = shiny;
		} else if (gameObject.name == "Boleg") {
			bolegRend.material = shiny;
		}
	}

	public void SpawnGlowOff() {
		olegupperRend.material = norm;
		oleglowerRend.material = norm;
		bolegRend.material = norm;
	}

	public void IconDisable() {
		if (gameObject.name == "Oleg") {
			olegiconrend [dieCount].enabled = false;
		} 

		else if (gameObject.name == "Boleg") {
			bolegiconrend [dieCount].enabled = false;
		}
		}

	public void SplashIconDisable() {
		if (gameObject.name == "Oleg") {
			olegsplashiconhandler (dieCount);
		} else if (gameObject.name == "Boleg") {
			bolegsplashiconhandler (dieCount);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody2D>();
		sounds = GetComponents<AudioSource> ();
		olegIcons = new GameObject[numIcons];
		bolegIcons = new GameObject[numIcons];
		bolegsplashIcons = new GameObject[numIcons];
		olegsplashIcons = new GameObject[numIcons];
		olegiconrend = new Renderer[numIcons];
		bolegiconrend = new Renderer[numIcons];
		bolegsplashiconrend = new Renderer[numIcons];
		olegsplashiconrend = new Renderer[numIcons];

		for (int i = 0; i < numIcons; i++) {
			f++;
			olegIcons[i] = GameObject.Find(string.Concat("DeathIcon_Player1-", f.ToString()));
			bolegIcons[i] = GameObject.Find(string.Concat("DeathIcon_Player2-", f.ToString()));;
			bolegsplashIcons[i] = GameObject.Find(string.Concat("BolegUI_", f.ToString()));;
			olegsplashIcons[i] = GameObject.Find(string.Concat("OlegUI_", f.ToString()));;
			olegiconrend[i] = olegIcons[i].GetComponent<Renderer>();
			bolegiconrend[i] = bolegIcons[i].GetComponent<Renderer>();
			bolegsplashiconrend[i] = bolegsplashIcons[i].GetComponent<Renderer>();
			olegsplashiconrend[i] = olegsplashIcons[i].GetComponent<Renderer>();
		}
    }
	
	// Update is called once per frame
	void Update () {
		SplashIconDisable (); 
		/* if(projectile != null && projectile.gameObject.tag== "Projectile")
         {
             playerCtrl.OnTriggerEnter2D(projectile);
             Destroy(gameObject);
         }

       */



    }
}
