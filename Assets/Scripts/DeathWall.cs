using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doodle
{
    public class DeathWall : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl pControl;

        [SerializeField]
        private Camera mainCamera = new Camera();
        [SerializeField]
        private GameGui gameGui;
        private Vector2 pos;

        // Start is called before the first frame update
        void Start()
        {
            pos = gameObject.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

            MovinOnUp();
            
        }
        public void MovinOnUp()
        {
            pos.y += 0.5f * Time.deltaTime;
            gameObject.transform.position = pos;
        }

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