using System;
using UnityEngine;
using UnityEngine.UI;

namespace EndGame
{
    public class EndGameScore : MonoBehaviour
    {
        ScoreScript scoreScript;

        public Text scoreText;
        public Text highScoreText;

        private void Start()
        {
            highScoreText.text = ScoreScript.highScoreValue.ToString();
            scoreText.text = ScoreScript.ScoreValue.ToString();
        }
    }
}