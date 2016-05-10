using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public float gravity = -15f;
    bool facingRight = true;
    public string horizontalInput = "Horizontal_P1";
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    Animator anim;
    Rigidbody2D rigidB2D;

    // Use this for initialization
    void Start () {
        rigidB2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


        float move = Input.GetAxis(horizontalInput);

        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidB2D.velocity = new Vector2(move * maxSpeed, rigidB2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

       // rigidB2D.velocity += new Vector2 (0,gravity * Time.deltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
