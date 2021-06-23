using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

namespace Doodle
{
    public class GameGui : MonoBehaviour
    {
        [SerializeField]
        private PlayerControl playControl;

        [SerializeField]
        private new Camera camera;

        [SerializeField]
        private Scoring score;

        [SerializeField]
        private SaveLoad.SaveLoad saveLoad; //saveLoad is very popular Allows for saving and loading

        [SerializeField]
        private AudioManager audioM; //Managing the Audio 

        public TextMeshProUGUI timerText; // text for the timer
        [SerializeField]
        private TextMeshProUGUI gameOverText;
        [SerializeField]
        private TextMeshProUGUI score2Beat;
        public TextMeshProUGUI winningScore; // the score that shows up as you beat the game
        public TextMeshProUGUI savedScore; // the score that shows up as you save the score

        public Button saveButton;
        public Button reloadButton;
        [SerializeField]
        private GameObject minMap;


        public bool gameOver;

        [SerializeField]
        private GameObject gameLoader;
        [SerializeField]
        private GameObject mMenuEelemts;
        [SerializeField]
        private GameObject deathWall;
        public bool startedGame = false;

        public float timer;

        private void Start()
        {
            savedScore.text = $"Saved Score \n {score.savedScore.ToString("F2")}"; // the saved score is currently what was saved to the variable.
        }

        // Update is called once per frame
        void Update()
        {        
            Timer();
            // if the player won the game,
            //deactivate the death barrier
            if (playControl.wonGame)
            {
                WonGame();
                deathWall.SetActive(false);
            }
            // if they die, activate the LoseGame function.
            if (playControl.dead)
            {
                LoseGame();
            }
        }
        /// <summary>
        /// When clicked activates the gameObject that contains the level, activates the position constraint,
        /// enables the timer text and lets the game know it's started.
        /// </summary>
        public void PlayGame()
        {
            minMap.SetActive(true);
            gameLoader.SetActive(true);
            mMenuEelemts.SetActive(false);
            camera.GetComponent<PositionConstraint>().constraintActive = true;
            camera.GetComponent<PositionConstraint>().enabled = true;
            timerText.gameObject.SetActive(true);
            startedGame = true;
           
        }
        /// <summary>
        /// exits out of playmode and/or the EXE upon clicking.
        /// </summary>
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        private void Timer()
        {
            if (startedGame == true)
            {
                timer += 1 * (Time.deltaTime);
                timerText.text = timer.ToString("F0");  
            }
        }

        /// <summary>
        /// upon winning, saves out the score as what the timer variable was
        /// and activates the "win screen"
        /// while giving you the option to save the time it took as binary serialisation.
        /// </summary>
        public void WonGame()
        {

            camera.GetComponent<PositionConstraint>().enabled = false;
            camera.GetComponent<PositionConstraint>().constraintActive = false;

            startedGame = false;
            score.highScore = timer; // makes the high score equal the current value of the timer
            score.savedScore = timer; // same as above but for the savedScore.
            
            winningScore.gameObject.SetActive(true); //the text for your winning score appears,
            timerText.gameObject.SetActive(false); //the timer text is deactivated
            //the winning score text is modified to show your results
            winningScore.text = $"You completed the game in {score.highScore.ToString("F2")} seconds! \n Would you like to save this score?";
            //activates the save and mainMenu button
            saveButton.gameObject.SetActive(true);
            reloadButton.gameObject.SetActive(true);            
        }
        /// <summary>
        /// Tells you how long it took for you to die by using the timer as an indicator
        /// also disables the player.
        /// </summary>
        public void LoseGame()
        {
            minMap.SetActive(false);
            score.highScore = timer;
            startedGame = false;
            timerText.gameObject.SetActive(false);
            gameOverText.text = $"You died in {score.highScore.ToString("F2")} seconds.\n No saving for you!";
            gameOverText.gameObject.SetActive(true);
            reloadButton.gameObject.SetActive(true);

        }
        /// <summary>
        /// saves out your score via Binary Serialisation
        /// </summary>
        public void SaveScore()
        {
            savedScore.text = $"Saved Score \n {score.highScore.ToString("F2")}";
            score.savedScore = timer;

            saveLoad.SaveBinary(score);//using the saveLoad Script function for saving out binary
            //it's referenced here because scoring does not inherit from monobehaviour and isn't part of inheritance.
        }

        /// <summary>
        /// loads the current saved score via Binary
        /// </summary>
        public void LoadScore()
        {
            score = saveLoad.LoadBinary(); // the score now equals whatever was saved in Binary last time.

            savedScore.text = $"Saved Score \n {score.highScore.ToString("F2")}";//changing the text to the score saved
        }
        /// <summary>
        /// essentially refreshes the game.
        /// </summary>
        public void LoadMenu()
        {
            SceneManager.LoadScene("Fixed Game v2");
        }

    }
}