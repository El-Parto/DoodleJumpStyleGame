using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doodle
{
    public class PlatformSpawner : MonoBehaviour
    {
        public PlayerControl pCntrl;

        [SerializeField]
        private GameObject platform; // the type of object used
        [SerializeField]
        private GameObject spawnArea; //the game object that is used to deactivate or activate the entire spawner
        [SerializeField]
        private GameObject winCon; // the object to be described as the Win condition

        [SerializeField]
        private int platformCount = 100; // how many platforms are there

        //the min/max values for the X position
        private int minXpos = -50;
        private int maxXpos = 50;

        //the min max values for the Y position
        public int maxYheight = 200;
        public int minYheight = 0;



        // Start is called before the first frame update
        void Start()
        {
            Spawner();
        }

        // Update is called once per frame
        void Update()
        {
            //if you won the game, the platforms dissapear
            if (pCntrl.wonGame)
                spawnArea.gameObject.SetActive(false);
        }
        /// <summary>
        /// The positions of the platforms are randomly set and then instantiated across
        /// the Min/Max values of X and Y
        /// The win con is also spawned at a set postion.
        /// </summary>
        private void Spawner()
        {

            Vector3 platformPos = new Vector3(0, Random.Range(minYheight, maxYheight));
            Vector3 winPos = new Vector3(0, 200);

            Instantiate(winCon, winPos, Quaternion.identity);

            for (int i = 0; i < platformCount; i++)
            {
                platformPos.y = Random.Range(minYheight, maxYheight);
                platformPos.x = Random.Range(minXpos, maxXpos);

                
                //instantiates platforms based on the platform pos using quaterinion identity rotation with guidance of the spawn area's transform.
                Instantiate(platform,  platformPos, Quaternion.identity, spawnArea.transform);
            }
 
        }
    }
}