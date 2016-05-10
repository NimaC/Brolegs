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
			Vector3 temp = new Vector3(0,-7.5f,-4.3f);
			rBody.transform.position = temp;
			dieCount = dieCount + 1;
			Debug.Log(dieCount);

		} 
		else if (col.gameObject.tag == "Projectile" && dieCount == 3) {
			GetComponent<PlayerController> ().enabled = false;
			GetComponentInChildren<AttackScript> ().enabled = false;
			anim.Play (dieState);
			transform.gameObject.AddComponent<GameOverScript> ();
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
