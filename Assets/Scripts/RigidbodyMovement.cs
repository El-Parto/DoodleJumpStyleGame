using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;

    //public bool isHorriMoving;
    public float moving = 1;
    //public float tempDash = 2;

    public float moveSpeed = 20;
    public float jumpHeight = 20;

    public float bounceMult = 2;
    public PhysicsMaterial2D bouncer;
    public bool ableToBounce true;

    [SerializeField]
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        // isHorriMoving = false;
        bouncer = GetComponent<PhysicsMaterial2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerRB.velocity = new Vector2(moving, playerRB.velocity.y);

        HorizontalMove();
        

    }

    private void FixedUpdate()
    {
        VerticalMove();
    }


    private void VerticalMove()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity += Vector2.up * jumpHeight;
        }

    }

    private void Bouncing( float timer)
    {
        timer = 1.5f;
        //so when you press space, you launch yourself higher by multipying the bounce of the platform Physic
        if (Input.GetKeyDown(KeyCode.Space)&& timer > 0)
        {
            timer = timer-- * (Time.deltaTime * 0.5f);
            bouncer.bounciness = bouncer.bounciness * bounceMult;


        }
        if (isGrounded && ableToBounce)
            timer = 1.5f;
    }

    private void HorizontalMove()
    {
        //isHorriMoving = true;
        moving = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        //InherentDash();
    }

    public void InherentDash()
    {
        //tempDash = tempDash + moving * Time.deltaTime;
        //if(tempDash <= moving && isHorriMoving)
        //{
        //    tempDash = tempDash - (moving * 0.5f);

        //}
        //else if (!isHorriMoving)
        //{
        //    tempDash = 0;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jumpable")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }



}
