using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodle
{
    public class PlayerControl : MonoBehaviour
    {
        

        private Rigidbody2D playerRB;

        [SerializeField]
        private AudioManager aManager;

        public bool canMove = true;

        public float moving = 1;
        public float moveSpeed = 20;
        public float jumpHeight = 10;
        public float bounceMult = 2;
        //public PhysicsMaterial2D bouncer;
        [SerializeField]
        //private Vector2 bounceVel;
        public bool ableToBounce = false;
        public bool bouncePress = false;

        [SerializeField]
        private bool isGrounded = true;

        public bool wonGame = false;



        // Start is called before the first frame update
        void Start()
        {
            playerRB = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            playerRB.velocity = new Vector2(moving, playerRB.velocity.y);
            HorizontalMove();
            VerticalMove();
            Bouncing();
            if (wonGame)
            {
                canMove = false;
                Suprise();
            }
                

        }

        private void VerticalMove()
        {
            if (canMove)
            {
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    playerRB.velocity += Vector2.up * jumpHeight;
                }
            }
        }
        private void HorizontalMove()
        {
            //isHorriMoving = true;
            if (canMove)
            {
                moving = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            //InherentDash();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Jumpable")
            {
                isGrounded = true;
            }
            if (collision.gameObject.tag == "Win Con")
            {
                wonGame = true;
                playerRB.velocity = playerRB.velocity * 0; //negates all velocity
                moveSpeed = 0;
            }
        }
        public void Suprise()
        {
            float _pitch;
            _pitch = aManager.gameBGM.pitch;
            aManager.gameBGM.pitch = Mathf.Lerp(_pitch, 0, 1 * Time.deltaTime);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "BounceTrigger")
            {
                ableToBounce = true;
            }
        }


        /// <summary>
        /// If able to bounce and press space while able to bounce,
        /// multiply the physics material 2d bounciness by the variable
        /// and makes your character bounce higher like an "action command".
        /// </summary>
        private void Bouncing()
        {
            if (ableToBounce)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerRB.velocity = new Vector2(moveSpeed, (playerRB.velocity.y * bounceMult));
                    Debug.Log("bounce");
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    ableToBounce = false;
                    Debug.Log("off bounce");
                }
            }
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            ableToBounce = false; // sets being able to bounce to false

        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            // since the only collision will come from the initial ground,
            // setting the "grounded" status on collision should be fine
            isGrounded = false;

        }


    }
}