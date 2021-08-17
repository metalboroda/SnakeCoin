using UnityEngine;

namespace MainMenu
{
    public class Sound : MonoBehaviour
    {
        static Sound _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
        }

        public void ToggleMusic()
        {
            if (PlayerPrefs.GetInt("MusicMuted", 0) == 0)
            {
                PlayerPrefs.SetInt("MusicMuted", 1);
                // AudioListener.volume = 1;
            }
            else
            {
                PlayerPrefs.SetInt("MusicMuted", 0);
                // AudioListener.volume = 0;
            }
        }

        public void ToggleSFX()
        {
            if (PlayerPrefs.GetInt("SFXMuted", 0) == 0)
            {
                PlayerPrefs.SetInt("SFXMuted", 1);
                // AudioListener.volume = 1;
            }
            else
            {
                PlayerPrefs.SetInt("SFXMuted", 0);
                // AudioListener.volume = 0;
            }
        }
    }
}