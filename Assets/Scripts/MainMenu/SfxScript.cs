using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MainMenu
{
    public class SfxScript : MonoBehaviour
    {
        private Sound _sound;
        public AudioMixer audioMixer;
        public Button sfxToggleButton;
        public Sprite sfxOnSprite;
        public Sprite sfxOffSprite;

        // Start is called before the first frame update
        void Start()
        {
            _sound = GameObject.FindObjectOfType<Sound>();
            UpdateSfxMusicIconandVolume();
        }

        public void SfxVolumeToggle()
        {
            _sound.ToggleSFX();
            UpdateSfxMusicIconandVolume();
        }

        void UpdateSfxMusicIconandVolume()
        {
            if (PlayerPrefs.GetInt("SFXMuted", 0) == 0)
            {
                // AudioListener.volume = 1;
                audioMixer.SetFloat("SFX", -0f);
                sfxToggleButton.GetComponent<Image>().sprite = sfxOnSprite;
            }
            else
            {
                // AudioListener.volume = 0;
                audioMixer.SetFloat("SFX", -80f);
                sfxToggleButton.GetComponent<Image>().sprite = sfxOffSprite;
            }
        }
    }
}