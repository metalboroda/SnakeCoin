using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class ButtonsScript : MonoBehaviour
    {
        public void ToGame()
        {
            SceneManager.LoadScene("1_Game");
        }
    }
}