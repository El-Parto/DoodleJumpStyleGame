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
    public bool ableToBounce = false;



    [SerializeField]
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        // isHorriMoving = false;
        //bouncer = GetComponent<PhysicsMaterial2D>();
       // playerColl = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerRB.velocity = new Vector2(moving, playerRB.velocity.y);
        


        HorizontalMove();
        VerticalMove();
        
    }

    


    private void VerticalMove()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity += Vector2.up * jumpHeight;
        }

    }

    private void Bouncing()
    {
        if (ableToBounce)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bouncer.bounciness = bouncer.bounciness * bounceMult;
                bouncer.bounciness = Mathf.Clamp(bouncer.bounciness, 0, 2);
            }
        }
    }

    private void HorizontalMove()
    {
        //isHorriMoving = true;
        moving = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
        //InherentDash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Bouncy")
        {
            ableToBounce = true;
            Bouncing();
        }
            
        Debug.Log("buffer start");

        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        ableToBounce = false;
        bouncer.bounciness = 1;
        Debug.LogWarning("buffer has stopped");
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jumpable")
        {
            isGrounded = true;
            ableToBounce = true;
        }
        if (collision.gameObject.tag == "Bouncy")
        {
            ableToBounce = true;
        }

        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }



}
