using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doodle
{
    /// <summary>
    /// Moves the Death Barrier in the positive Y direction over time
    /// </summary>
    public class DeathWall : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl pControl;

        [SerializeField]
        private Camera mainCamera = new Camera();
        [SerializeField]
        private GameGui gameGui;
        private Vector2 pos;// controlling the position of the gameObject

        // Start is called before the first frame update
        void Start() => pos = gameObject.transform.position;


        // Update is called once per frame
        void Update()
        {
            MovinOnUp();            
        }
        /// <summary>
        /// add 0.5 (multiplied by Time.deltaTime)  to the object's transform's Y position
        /// </summary>
        public void MovinOnUp()
        {
            pos.y += 0.5f * Time.deltaTime; //the variable that keeps adding itself in the Update Method so that it can move over time.
            gameObject.transform.position = pos; // what makes the gameobject move.
        }

        /// <summary>
        ///  if the barrier touches the player
        ///  kill the player by making them dead and deactivate their existance
        ///  while making the camera set in world space.
        /// </summary>        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                
                mainCamera.gameObject.transform.SetParent(null);
                pControl.dead = true;
                pControl.gameObject.SetActive(false);
            }
        }


    }
}