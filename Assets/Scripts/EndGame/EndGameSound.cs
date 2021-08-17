using MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace EndGame
{
    public class EndGameSound : MonoBehaviour
    {
        public AudioSource loseSound;

        // Start is called before the first frame update
        void Start()
        {
            loseSound = GetComponent<AudioSource>();
            /*GameObject.FindGameObjectWithTag("MainMenuSoundtrack").GetComponent<SoundtrackScript>().StopMusic();*/
        }
    }
}