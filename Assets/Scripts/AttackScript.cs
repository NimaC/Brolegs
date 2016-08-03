using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    public Rigidbody2D projectile;
    private float speed = 33f;
    private float gravity = -30f;
    //public string gunButton = "Fire_P1";
    private PlayerController playerCtrl;
    public string fireButton = "Fire_P1";
	public int knifeCount;
    private float timeLeft = 5.0f;

	public AudioSource[] sounds;
	AudioSource audio;
	// AudioSource audio1;

	private GameObject knifeicon1;
	private GameObject knifeicon2;
	private GameObject knifeicon3;
	private Renderer rendknifeicon1;
	private Renderer rendknifeicon2;
	private Renderer rendknifeicon3;
    

	void Awake ()
    {
		playerCtrl = transform.root.GetComponent<PlayerController>();
		knifeicon1 = GameObject.Find("Knife_Icon_Player1-1");
		knifeicon2 = GameObject.Find("Knife_Icon_Player1-2");
		knifeicon3 = GameObject.Find("Knife_Icon_Player1-3");
		rendknifeicon1 = knifeicon1.GetComponent<Renderer>();
		rendknifeicon2 = knifeicon2.GetComponent<Renderer>();
		rendknifeicon3 = knifeicon3.GetComponent<Renderer>();
	}

	// Use this for initialization
	void Start () {
		knifeCount = 3;
		sounds = GetComponents<AudioSource>();
	}

	void Refillknives() {
		if (knifeCount < 3)
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				audio = sounds [2];
				audio.Play();
				knifeCount = knifeCount + 1;
				timeLeft = 3.5f;
			}
		}
	}

	void IconHandler(){
		if (knifeCount == 3) {
			rendknifeicon3.enabled = true;
			rendknifeicon2.enabled = true;
			rendknifeicon1.enabled = true;
		} else if (knifeCount == 2) {
			rendknifeicon3.enabled = false;
			rendknifeicon2.enabled = true;
			rendknifeicon1.enabled = true;
		} else if (knifeCount == 1) {
			rendknifeicon3.enabled = false;
			rendknifeicon2.enabled = false;
			rendknifeicon1.enabled = true;
		} else {
			rendknifeicon3.enabled = false;
			rendknifeicon2.enabled = false;
			rendknifeicon1.enabled = false;
		}
	}

	void chooseRndSnd() {
		int numb = (int) Random.Range (0f, 2f);
		audio = sounds [numb];
	}

    // Update is called once per frame
    void Update () {
			
		Refillknives ();
		IconHandler();

            if (Input.GetButtonDown(fireButton) && knifeCount > 0)
            {
			chooseRndSnd ();
			audio.Play();
			knifeCount = knifeCount - 1;
			// Invoke ("Refillknives", 5);
            //playerCtrl.playerShoot();
            if(playerCtrl.facingRight)
            {
                Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
				projectileInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                projectileInstance.velocity = new Vector2(-speed, 0);
            }
        }
	
	}
}
