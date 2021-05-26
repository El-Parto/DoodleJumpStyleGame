using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;

    public bool isHorriMoving;
    public float moving = 1;
    public float tempDash = 2;

    public float moveSpeed = 20;
    public float jumpHeight = 20;

    [SerializeField]
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        isHorriMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMove();
        playerRB.velocity = new Vector2(moving, playerRB.velocity.y);

        HorizontalMove();
        

    }

    private void VerticalMove()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.velocity += Vector2.up * jumpHeight * Time.deltaTime;
        }
        

    }


    private void HorizontalMove()
    {
        isHorriMoving = true;
        moving = Input.GetAxisRaw("Horizontal") * moveSpeed + tempDash;
        
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
