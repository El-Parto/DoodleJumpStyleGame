using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Doodle
{


    //serving as data for player (?)
    // basically the monobehaviour so you can place it on the player.
    public class Scoring : MonoBehaviour
    {

        public PlayerControl playCont;
        private GameGui gui;

        public float timer;

        
        public int highScore;

        public bool startedGame = false;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Timer();
        }

        private void Timer()
        {
            if (startedGame)
                timer = timer++ * Time.deltaTime;
        }
    }
}