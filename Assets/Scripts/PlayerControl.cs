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
            //these control the Animator bools
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

        /// <summary>
        /// if you can move, and press the associated jump key while grounded,
        /// your velocity in the y direction increases, allowing you to jump.
        /// </summary>
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

        /// <summary>
        /// If you can move, then your speed is now the input of Horizontal * Movespeed
        /// </summary>
        private void HorizontalMove()
        {
            //isHorriMoving = true;
            if (canMove)
            {
                moving = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            //InherentDash();
        }
        /// <summary>
        /// When colliding with various tags, activates the associated bool and performs specific events.
        /// </summary>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Jumpable")
            {
                isGrounded = true; // this is so the player may jump again after touching the ground
            }
            //if the win con is touched, you win the game.
            if (collision.gameObject.tag == "Win Con")
            {
                wonGame = true;
                playerRB.velocity = playerRB.velocity * 0; //negates all velocity
                moveSpeed = 0;
            }
        }
        //public void Suprise()
        //{ was going to modify pitch whenever you finished the game. I mean, there's no reason for this not to happen but
        //    //float _pitch;
        //    //_pitch = aManager.gameBGM.pitch;
        //   // aManager.gameBGM.pitch = Mathf.Lerp(_pitch, 0, 1 * Time.deltaTime);
        //}

        /// <summary>
        /// When you enter a trigger that is named BounceTrigger, you are able to bounce
        /// </summary>
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
                    playerRB.velocity = new Vector2(moveSpeed, (playerRB.velocity.y * bounceMult));// velocity is multiplied by bounce mult
                    Debug.Log("bounce");
                }
                //when you release the key, you lose your chance to bounce while inside the trigger zone
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    ableToBounce = false;
                    Debug.Log("off bounce");
                }
            }
        }

        /// <summary>
        /// after exiting the trigger, your are no longer able to increase your velocity.
        /// </summary>
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