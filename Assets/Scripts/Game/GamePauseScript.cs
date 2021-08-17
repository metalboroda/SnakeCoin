using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace Game
{
    public class GamePauseScript : MonoBehaviour
    {
        private bool isPaused = false;

        public AudioMixer audioMixer;
        public AudioSource pauseMusic;
        public GameObject pausePanel;
        public Button gamePauseToggle;
        public Sprite pauseSprite;
        public Sprite playSprite;

        public void pauseGame()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                gamePauseToggle.GetComponent<Image>().sprite = pauseSprite;
                pausePanel.SetActive(false);
                pauseMusic.enabled = false;
                audioMixer.SetFloat("Music", -0f);
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                gamePauseToggle.GetComponent<Image>().sprite = playSprite;
                pausePanel.SetActive(true);
                pauseMusic.enabled = true;
                audioMixer.SetFloat("Music", -80f);
            }
        }
    }
}