using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class PauseExitButton : MonoBehaviour
    {
        public void ToMainMenu()
        {
            Time.timeScale = 1;
            LifeScript.lifeCount = 3;
            ScoreScript.ScoreValue = 0;
            SceneManager.LoadScene("0_MainMenu");
        }
    }
}