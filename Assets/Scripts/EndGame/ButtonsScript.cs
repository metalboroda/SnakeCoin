using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndGame
{
    public class ButtonsScript : MonoBehaviour
    {
        public void RepeatGame()
        {
            LifeScript.lifeCount = 3;
            ScoreScript.ScoreValue = 0;
            SceneManager.LoadScene("1_Game");
        }

        public void ToMainMenu()
        {
            LifeScript.lifeCount = 3;
            ScoreScript.ScoreValue = 0;
            SceneManager.LoadScene("0_MainMenu");
        }
    }
}