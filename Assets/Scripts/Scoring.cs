using UnityEngine;
namespace Doodle
{
    //serving as data for player (?)
    // basically the monobehaviour so you can place it on the player.
    [System.Serializable]
    public class Scoring
    {
        // if a serialise execption occurs, this prevents Unity from thinking that
        // it needs to serialise the entirety of the the referenced script.
        // E.G only this script is meant to be scriptable, but not the other scripts
        // so you add System.NonSerilized to the variable, it wont count it.
        [System.NonSerialized]
        private PlayerControl playCont;
        [System.NonSerialized]
        private GameGui gui;        

        public float highScore = 999;
        public float savedScore = 999;
    }
}