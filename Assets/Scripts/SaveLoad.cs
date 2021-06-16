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
        private GameGui gui;


        public Scoring score;

        private string FilePath => Application.streamingAssetsPath + "/score";

        // Start is called before the first frame update
        void Start()
        {
            ValidateFolder(Application.streamingAssetsPath);
        }

        private void ValidateFolder(string _folder)
        {
            string folderName = "scoreFolder";
            _folder = folderName;
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Load()
        {
            LoadBinary();
        }
        public void Save()
        {
            SaveBinary();
        }



        private void SaveBinary()
        {

            // * This opens the "river" between the RAM and the file.
            // creating te river                         file loc'             river? Important.
            using (FileStream stream = new FileStream(FilePath + ".save", FileMode.OpenOrCreate))
            {

                // like creating the boat that will carry the data from one point to another.
                BinaryFormatter formatter = new BinaryFormatter();

                //give memory stream
                //* transports the data from the RAM to the specified file
                // * like freezing water into ice.
                formatter.Serialize(stream, score);

            }
        }
        private void LoadBinary()
        {
            //if there is no save data we shouldn't attempt to load it
            if (!File.Exists(FilePath + ".save"))
                return;

            // * This opens the "river" between the RAM and the file.
            // creating te river                         file loc'             river? Important.
            using (FileStream stream = new FileStream(FilePath + ".save", FileMode.Open))
            {

                // like creating the boat that will carry the data from one point to another.
                BinaryFormatter formatter = new BinaryFormatter();

                score = formatter.Deserialize(stream) as Scoring;

            }


        }
    }
}