using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace Doodle
{
    public class AudioManager : MonoBehaviour
    {

        public Slider bgmSlider; // slider variable
        public TextMeshProUGUI bgmText; // TMP Text variable

        //public float bgmValue; // bgm music value

        [SerializeField] private AudioMixer mixer; // Note to self, use Audio Mixer instead of AudioSource
        [SerializeField] private string menuParam = "MenuAudio"; // used with Exposed Parameter in AudioMixer in the Unity window
        [SerializeField] private string gameParam = "GameAudio"; // used with Exposed Parameter in AudioMixer in the Unity window

        [SerializeField] private AudioSource gameBGM;//forgive me James(teacher) i wanted to change the pitch of the audio source. I know there's the value in exposed parameter but i don't need to save it so YOLO

        private float sliderValue; // the valu e that is used to store saved values for PlayerPrefs

        [SerializeField]
        private GameGui gameGui;

        private void Awake()
        {
            bgmSlider.maxValue = 0; // set up the mix value
            bgmSlider.minValue = -100; // set up the max value for slider

                

            // setting the previous values from playerprefs here
            //if (PlayerPrefs.HasKey(menuParam))
            //{
            //    //float slider value now equals whatever the PlayerPrefs had saved before
            //    PlayerPrefs.GetFloat(menuParam);
            //    sliderValue = PlayerPrefs.GetFloat(menuParam);
            //    //bgmSlider.value = PlayerPrefs.GetFloat(menuParam);


            //}
           // bgmSlider.value = PlayerPrefs.GetFloat(menuParam);
        }




        // Start is called before the first frame update
        void Start()
        {

            if (PlayerPrefs.HasKey(menuParam))
            {
                bgmSlider.value = PlayerPrefs.GetFloat(menuParam); // The slider takes in the value from what playerPrefs saved
                mixer.SetFloat(menuParam, sliderValue);// The Audio mixer mixer then sets the volume float based on the saved value.
            }

        }

        // Update is called once per frame
        void Update()
        {
            bgmText.text = $"BGM: {Mathf.RoundToInt(bgmSlider.value + 100)}%"; //changing the BGM text.
            MuteMenuMusic();

        }


        /// <summary>
        /// turns on Game Music and turns Menu music to -100 dB
        /// </summary>
        public void TurnOnMusic()
        {
 

            if (gameGui.startedGame == true)
            { 
                mixer.SetFloat(gameParam, 0);// sets the game param float volume to 0 (which means normal volume)
            }
            else
                mixer.SetFloat(gameParam, -100);// sets game param to -100 otherwise
            gameBGM.Play(); // plays the audio as it didn't start from awake (to make sure the audio starts from the beginning)
        }


        /// <summary>
        /// if the game has started, turn down the exposed parameter for menuParam
        /// and set the exposed parameter for gameParam to the current bgmSlider value.
        /// </summary>
        public void MuteMenuMusic()
        {
            
            if (gameGui.startedGame == true)
            {
                mixer.SetFloat(menuParam, -100);
                mixer.SetFloat(gameParam, bgmSlider.value);
            }
        }

        /// <summary>
        /// Changes the volume of the audio (Game BGM and Menu BGM respectively)
        /// based on bgmSlider's Value.
        /// </summary>
        public void OnValueChanged()
        {
            //if game ahas started
            if(gameGui.startedGame == true)
            {
                //set the current volume of the ingame audio to the bgm slider value
                mixer.SetFloat(gameParam, bgmSlider.value);
                //update the variable value to match gui slider value.
                
                Debug.Log($"gameAudio has been set to{PlayerPrefs.GetFloat(menuParam)}");

            }
            else//set the current volume of the ingame audio to the bgm slider value
            {               
                mixer.SetFloat(menuParam, bgmSlider.value);
                Debug.Log($"MenuAudio has been set to{PlayerPrefs.GetFloat(menuParam)}");
            }
            sliderValue = bgmSlider.value; //the new slider value is replaced by the current GUI slider value
        }

        /// <summary>
        /// I had to make a save function here for the PlayerPrefs because it doesn't like being saved in the slider's
        /// "OnValueChanged" function.
        /// I had more trouble with this than I should of.
        /// Saves out PlayerPrefs.
        /// </summary>
        public void PlayerPrefSave()
        {
            //this only sets the slider position
            PlayerPrefs.SetFloat(menuParam, bgmSlider.value); // sets the menu param based on the slider variable

            //this will set the volume position
            PlayerPrefs.SetFloat(menuParam, sliderValue); // sets the menu param based on the slider variable
            PlayerPrefs.Save();// saves the "set floats" out

        }
    }
}