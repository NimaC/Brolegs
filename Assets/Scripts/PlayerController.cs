using UnityEngine;
using System.Collections;
using Prime31;


public class PlayerController : MonoBehaviour
{

    //Bewegung Einstellungen
    public float gravity = -30f;
    public float runSpeed = 8f;
    public string horizontalInput = "Horizontal_P1";
    public string jumpButton = "Jump_P1";
    public string fireButton = "Fire_P1";
    [HideInInspector]
    public bool facingRight = true;
    public float move = 0f;
    private Rigidbody2D rBody;

    private CharacterController2D _controller;

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
            var targetJumpHeight = 3.5f;
            velocity.y = Mathf.Sqrt(2f * targetJumpHeight * -gravity);
            anim.SetTrigger("Jump");
           
        }

        if (Input.GetButtonDown(fireButton))
        {
            anim.SetTrigger("Fire");
        }



        //Schwerkraft hinzufügen
        velocity.y += gravity * Time.deltaTime;
        _controller.move(velocity * Time.deltaTime);
        anim.SetFloat("vSpeed", velocity.y);

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

