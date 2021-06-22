using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

        public bool dead = false;
        private bool running = false;
        [SerializeField]
        private bool isGrounded = true;

        public bool wonGame = false;

        [SerializeField]
        private Animator anim;

       

        // Start is called before the first frame update
        void Start()
        {
            playerRB = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("Running", Mathf.Abs(moving));
            
            playerRB.velocity = new Vector2(moving, playerRB.velocity.y);
            HorizontalMove();
            VerticalMove();
            Bouncing();
            #region If statements
            if (wonGame)
            {
                canMove = false;
            }
            if (!isGrounded)
            {
                anim.SetBool("Jumping", true);
            }
            else
                anim.SetBool("Jumping", false);
            if (ableToBounce)
            {
                anim.SetBool("Bouncy", true);
                anim.SetBool("Jumping", false);
            }
            else
                anim.SetBool("Bouncy", false);
            #endregion
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
                //if (moving > 0.5)
                //{
                    
                    
                //    running = true;
                //    anim.SetBool("Running", running);
                //}

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
        //public void Suprise()
        //{ Not anymore :<
        //    //float _pitch;
        //    //_pitch = aManager.gameBGM.pitch;
        //   // aManager.gameBGM.pitch = Mathf.Lerp(_pitch, 0, 1 * Time.deltaTime);
        //}
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