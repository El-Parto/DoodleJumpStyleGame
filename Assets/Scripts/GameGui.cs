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
        private SaveLoad.SaveLoad saveLoad;

        [SerializeField]
        private AudioManager audioM;

        public TextMeshProUGUI timerText;
        [SerializeField]
        private TextMeshProUGUI gameOverText;
        [SerializeField]
        private TextMeshProUGUI score2Beat;
        public TextMeshProUGUI winningScore; // the score that shows up as you beat the game
        public TextMeshProUGUI savedScore; // the score that shows up as you save the score

        public Button saveButton;
        public Button reloadButton;

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
            savedScore.text = $"Saved Score \n {score.savedScore.ToString("F2")}";
        }

        // Update is called once per frame
        void Update()
        {        
            Timer();
            if (playControl.wonGame)
            {
                WonGame();
                deathWall.SetActive(false);
            }
            if (playControl.dead)
            {
                LoseGame();
            }
        }

        public void PlayGame()
        {
            gameLoader.SetActive(true);
            mMenuEelemts.SetActive(false);
            camera.GetComponent<PositionConstraint>().constraintActive = true;
            camera.GetComponent<PositionConstraint>().enabled = true;
            timerText.gameObject.SetActive(true);
            startedGame = true;
           
        }
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

        public void WonGame()
        {
            camera.GetComponent<PositionConstraint>().enabled = false;
            camera.GetComponent<PositionConstraint>().constraintActive = false;

            startedGame = false;
            score.highScore = timer;
            score.savedScore = timer;
            
            winningScore.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
            winningScore.text = $"You completed the game in {score.highScore.ToString("F2")} seconds! \n Would you like to save this score?";
            saveButton.gameObject.SetActive(true);
            reloadButton.gameObject.SetActive(true);            
        }
        public void LoseGame()
        {

            score.highScore = timer;
            startedGame = false;
            timerText.gameObject.SetActive(false);
            gameOverText.text = $"You died in {score.highScore.ToString("F2")} seconds.\n No saving for you!";
            gameOverText.gameObject.SetActive(true);
            reloadButton.gameObject.SetActive(true);

        }
        public void SaveScore()
        {
            savedScore.text = $"Saved Score \n {score.highScore.ToString("F2")}";
            score.savedScore = timer;

            saveLoad.SaveBinary(score);
        }

        public void LoadScore()
        {
            score = saveLoad.LoadBinary();

            savedScore.text = $"Saved Score \n {score.highScore.ToString("F2")}";
        }
        public void LoadMenu()
        {
            SceneManager.LoadScene("Fixed Game v1");
        }

    }
}