using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Doodle;

namespace SaveLoad
{
    public class SaveLoad : MonoBehaviour
    {
        //private GameGui gui;


        //public Scoring score;

        private string FilePath => Application.streamingAssetsPath + "/scoreData"; //String variable for the streaming assets path + /scoreData as a suffix.

        // Start is called before the first frame update
        void Start()
        {
            ValidateFolder(Application.streamingAssetsPath);
        }

        /// <summary>
        /// if the directory doesn't exist, creates a new one.
        /// </summary>
        /// <param name="_folder">folder name based off of the streaming assets path</param>
        private void ValidateFolder(string _folder)
        {
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);
        }



        /// <summary>
        /// Saves out the score from the class Scoring to Binary
        /// </summary>
        /// <param name="score"> the value attained when the timer stops after you beat the game.</param>
        public void SaveBinary(Scoring score)
        {
            // * This opens the "river" between the RAM and the file.
            // creating te river                         file loc'             river
            using (FileStream stream = new FileStream(FilePath + ".save", FileMode.OpenOrCreate))  // creating the channel that allows us to save.
            {
                // like creating the boat that will carry the data from one point to another.
                BinaryFormatter formatter = new BinaryFormatter(); //makes it able to save by specifying what type are we saving
                
                //give memory stream
                //* transports the data from the RAM to the specified file
                // * like freezing water into ice.
                formatter.Serialize(stream, score);// the saving command
            }
        }

        /// <summary>
        /// loads the binary data from the saved file and brings it in as score.
        /// </summary>
        /// <returns>it returns the values to the scoring class so that it may replace the varriables located there.</returns>
        public Scoring LoadBinary()
        {
            //if there is no save data we shouldn't attempt to load it
            if (!File.Exists(FilePath + ".save"))
                return null;

            // * This opens the "river" between the RAM and the file.
            // creating te river                         file loc'             river 
            using (FileStream stream = new FileStream(FilePath + ".save", FileMode.Open)) // opening up the channel to load from
            {
                // like creating the boat that will carry the data from one point to another.
                BinaryFormatter formatter = new BinaryFormatter(); //specifying the accesser need for it to load

                return (Scoring) formatter.Deserialize(stream); // loads here.
            }


        }
    }
}