using UnityEngine;
using System.Collections;
using Prime31;


public class BolegController : MonoBehaviour
{

    //Bewegung Einstellungen
	public Rigidbody2D Fire;
    public float gravity = -30f;
    public float runSpeed = 9f;
    public string horizontalInput = "Horizontal_P2";
    public string jumpButton = "Jump_P2";
    public string fireButton = "Fire_P2";
    [HideInInspector]
    public static bool facingRight = true;
    public float move = 0f;
    private Rigidbody2D rBody;
    private CharacterController2D _controller;
	public static float positionX;
	public static float positionY;
	public static float positionZ;
	public static float scaleX;
	public static float scaleY;
	public static float scaleZ;
    public bool fireBreathing;
	public float targetJumpHeight = 4.5f;

    //Animationen
    Animator anim;




    void Awake()
    {
        _controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
		positionX = transform.position.x;
		positionY = transform.position.y;        
		positionZ = transform.position.z;  

		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;

        var velocity = _controller.velocity;

        if (_controller.isGrounded)

            velocity.y = 0;


        //Horizontaler SpielerInput
        float h = Input.GetAxis(horizontalInput);

        move = velocity.x;

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (h > 0)
        {
            facingRight = true;
            velocity.x = runSpeed;
            goRight();
        }

        else if (h < 0)
        {
            facingRight = false;
            velocity.x = -runSpeed;
            goLeft();

        }

        else
        {
            velocity.x = 0;


        }

        //Vertikaler SpielerInput
        if (Input.GetButtonDown(jumpButton) && _controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(2f * targetJumpHeight * -gravity);
            anim.SetTrigger("Jump");


        }

        if (Input.GetButton(fireButton) && FireScript.fireTime > 0)
        {
            fireBreathing = true;
        }

        if (!Input.GetButton(fireButton) || FireScript.fireTime < 0)
        {
            fireBreathing = false;
        }



        //Schwerkraft hinzufügen
        velocity.y += gravity * Time.deltaTime;
        _controller.move(velocity * Time.deltaTime);

        anim.SetFloat("vSpeed", velocity.y);
		anim.SetBool("Fire", fireBreathing);
        anim.SetBool("Grounded", _controller.isGrounded);


    }



    void goLeft()
    {
        if (transform.localScale.x > 0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void goRight()
    {
        if (transform.localScale.x < 0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }


}

