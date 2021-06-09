using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Doodle
{


    public class GameGui : MonoBehaviour
    {
        [SerializeField]
        private Scoring scoreData;

        [SerializeField]
        private TextMeshProUGUI timerText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timerText.text = scoreData.timer.ToString("F0");
        }
    }
}