using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
namespace Doodle
{


    //serving as data for player (?)
    // basically the monobehaviour so you can place it on the player.
    public class Scoring : MonoBehaviour
    {

        public PlayerControl playCont;

        public float timer = Time.time;

        
        public int highScore;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}