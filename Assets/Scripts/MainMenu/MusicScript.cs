using UnityEngine;
using UnityEngine.Audio;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace MainMenu
{
    public class MusicScript : MonoBehaviour
    {
        private Sound _sound;
        public AudioMixer audioMixer;
        public Button musicToggleButton;
        public Sprite musicOnSprite;
        public Sprite musicOffSprite;

        // Start is called before the first frame update
        void Start()
        {
            _sound = GameObject.FindObjectOfType<Sound>();
            UpdateMusicIconAndVolume();
        }
    
        public void MusicVolumeToggle()
        {
            _sound.ToggleMusic(); // Updated our player prefs
            UpdateMusicIconAndVolume();
        }

        void UpdateMusicIconAndVolume()
        {
            if (PlayerPrefs.GetInt("MusicMuted", 0) == 0)
            {
                // AudioListener.volume = 1;
                audioMixer.SetFloat("Music", -0f);
                musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
            }
            else
            {
                // AudioListener.volume = 0;
                audioMixer.SetFloat("Music", -80f);
                musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
            }
        }
    }
}