using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodle
{

    public class BouncingScript : MonoBehaviour
    {
        public PlayerControl playRB; //the PlayerControl referenced as a variable (named with RB at the end to better suit what this script does
        public PhysicsMaterial2D bouncer; // referencing the Physics Material 2D
        public bool ableToBounce = false; 

        /// <summary>
        /// If you're able to bounce, the bounciness of the Physic material is 2.
        /// </summary>
        private void Bouncing()
        {
            if (ableToBounce)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    bouncer.bounciness = 2;
                    //bouncer.bounciness = Mathf.Clamp(bouncer.bounciness, 0, 2);
                }
            }
        }

        /// <summary>
        /// If you're in a trigger area that has "Bouncy" as the tag,
        /// you're able to bounce.
        /// And pressing and/or holding space will allow you to multiply that bounciness
        /// </summary>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Bouncy")
                ableToBounce = true;
            Debug.Log("buffer start");

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                bouncer.bounciness = bouncer.bounciness * playRB.bounceMult;
                bouncer.bounciness = Mathf.Clamp(bouncer.bounciness, 0, 2);
            }

        }
        /// <summary>
        /// After leaving the trigger, set the bounciness to 1
        /// </summary>
        private void OnTriggerExit2D(Collider2D collision)
        {

            ableToBounce = false;
            bouncer.bounciness = 1;
            Debug.LogWarning("buffer has stopped");
        }



    }
}