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

        public Slider bgmSlider;
        public TextMeshProUGUI bgmText;

        public float bgmValue;

        public AudioSource menuBGM;
        public AudioSource gameBGM;

        public GameGui gameGui;

        private void Awake()
        {
            gameBGM.mute = true;
        }




        // Start is called before the first frame update
        void Start()
        {
            bgmSlider.value = 1;
        }

        // Update is called once per frame
        void Update()
        {
            bgmText.text = $"BGM: {Mathf.RoundToInt(bgmSlider.value * 100)}%";

            VolumeChanger();

        }

        public void TurnOnMusic()
        {                      
            menuBGM.mute = true;            
            gameBGM.mute = !gameBGM.mute;
            gameBGM.Play();
        }

        public void VolumeChanger()
        {
            menuBGM.volume = bgmSlider.value;
            gameBGM.volume = bgmSlider.value;
        }
    }
}