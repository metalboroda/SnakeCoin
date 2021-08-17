using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public static int lifeCount = 3;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeCount = 3;
        lifeText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "LIFE " + lifeCount;
    }
}