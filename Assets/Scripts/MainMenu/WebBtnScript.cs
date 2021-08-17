using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebBtnScript : MonoBehaviour
{
    public void ToWebViewScene()
    {
        SceneManager.LoadScene("WebViewScene");
    }
}