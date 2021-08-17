using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int ScoreValue = 0;
    public static int highScoreValue;
    
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        highScoreValue = PlayerPrefs.GetInt("highScore", 0);
        score.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + ScoreValue;
    }
}