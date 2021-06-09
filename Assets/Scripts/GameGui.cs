using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Doodle
{


    public class GameGui : MonoBehaviour
    {
        public PlayerControl playControl;


        [SerializeField]
        private Scoring scoreData;

        [SerializeField]
        private TextMeshProUGUI timerText;

        [SerializeField]
        private GameObject gameLoader;
        [SerializeField]
        private GameObject mMenuEelemts;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timerText.text = scoreData.timer.ToString("F0");
        }

        private void WinGame()
        {
            if (playControl.wonGame == true)
            {
                //show win screen
                //save out time taken,
                //reset timer

            }
        }
        public void PlayGame()
        {
            gameLoader.SetActive(true);
            mMenuEelemts.SetActive(false);

        }
        public void QuitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
    }
}