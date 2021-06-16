using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodle
{

    public class BouncingScript : MonoBehaviour
    {
        public PlayerControl playRB;
        public PhysicsMaterial2D bouncer;
        public bool ableToBounce = false;

        private void Update()
        {

        }

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

        private void OnTriggerExit2D(Collider2D collision)
        {

            ableToBounce = false;
            bouncer.bounciness = 1;
            Debug.LogWarning("buffer has stopped");
        }



    }
}