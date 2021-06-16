using UnityEngine;
namespace Doodle
{
    //serving as data for player (?)
    // basically the monobehaviour so you can place it on the player.
    [System.Serializable]
    public class Scoring
    {

        public PlayerControl playCont;
        private GameGui gui;        
        public float highScore;



        public void RecordScore()
        {
            if (playCont.wonGame == true)
            {
                highScore = gui.timer;
            }
        }
    }
}