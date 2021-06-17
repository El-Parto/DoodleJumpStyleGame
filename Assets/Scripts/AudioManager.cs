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
        [SerializeField] private string gamePitchParam = "GamePitch"; // used with Exposed Parameter in AudioMixer in the Unity window

        public AudioSource gameBGM;//forgive me James(teacher) i wanted to change the pitch of the audio source. I know there's the value in exposed parameter but i don't need to save it so YOLO

        public GameGui gameGui;

        private void Awake()
        {   
        }




        // Start is called before the first frame update
        void Start()
        {
            //bgmSlider.value = 1;


            if (PlayerPrefs.HasKey(menuParam))
            {
                PlayerPrefs.GetFloat(menuParam);
            }
            else
            {
                //PlayerPrefs.SetFloat(menuParam,);
            }
            if (PlayerPrefs.HasKey(gameParam))
            {
                PlayerPrefs.GetFloat(gameParam);
            }
            else
            {
                //PlayerPrefs.SetFloat(gameParam, 1);
            }
        }

        // Update is called once per frame
        void Update()
        {
            bgmText.text = $"BGM: {Mathf.RoundToInt(bgmSlider.value * 100)}%";
            
            //VolumeChanger();

        }


        /// <summary>
        /// t
        /// </summary>
        public void TurnOnMusic()
        {
            mixer.SetFloat(menuParam, 0);
            mixer.SetFloat(gameParam, 100);
            //menuBGM.mute = true;            
            //gameBGM.mute = !gameBGM.mute;
            //gameBGM.Play();
        }


        /// <summary>
        /// Changes volume dynamically in game
        /// </summary>
        //public void VolumeChanger()
        //{
        //    mixer.SetFloat(menuParam, bgmSlider.value);
        //    mixer.SetFloat(gameParam, bgmSlider.value);
              //PlayerPrefs.Save();
        //}

        /// <summary>
        /// When you change the value on the slider, update the player prefs float
        /// and save them to player prefs
        /// </summary>
        public void OnValueChanged()
        {
            mixer.SetFloat(menuParam, bgmSlider.value);
            mixer.SetFloat(gameParam, bgmSlider.value);
            PlayerPrefs.SetFloat(menuParam, bgmSlider.value);
            PlayerPrefs.SetFloat(gameParam, bgmSlider.value);
            PlayerPrefs.Save();
        }
    }
}