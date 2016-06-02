using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

    public Rigidbody2D projectile;
    public float speed = 20f;
    public float gravity = -30f;
    //public string gunButton = "Fire_P1";
    private PlayerController playerCtrl;

    public string fireButton = "Fire_P1";


    void Awake ()
    {
        playerCtrl = transform.root.GetComponent<PlayerController>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown(fireButton))
        {
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
