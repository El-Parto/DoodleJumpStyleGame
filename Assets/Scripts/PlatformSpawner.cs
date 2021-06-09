using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doodle
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject platform;
        [SerializeField]
        private GameObject spawnArea;
        [SerializeField]
        private GameObject winCon;

        [SerializeField]
        private int platformCount = 100;

        private int minXpos = -50;
        private int maxXpos = 50;

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

        }

        private void Spawner()
        {

            Vector3 platformPos = new Vector3(0, Random.Range(minYheight, maxYheight));
            Vector3 winPos = new Vector3(0, 200);

            Instantiate(winCon, winPos, Quaternion.identity);

            for (int i = 0; i < platformCount; i++)
            {
                platformPos.y = Random.Range(minYheight, maxYheight);
                platformPos.x = Random.Range(minXpos, maxXpos);


                Instantiate(platform, platformPos, Quaternion.identity);
            }
            //foreach (GameObject platty in platformCount)
            //{

            //}   
        }
        //
        //private void Platforms(GameObject)
    }
}