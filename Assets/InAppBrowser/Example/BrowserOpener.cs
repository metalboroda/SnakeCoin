using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Android;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class BrowserOpener : MonoBehaviour
{
    public string pageToOpen;
    [SerializeField] private AudioSource music;

    // check readme file to find out how to change title, colors etc.
    public void OnButtonClicked()
    {
        music.enabled = false;

        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.displayURLAsPageTitle = false;
        options.androidBackButtonCustomBehaviour = true;

// Visual options
        options.backButtonText = "EXIT";
        options.hidesTopBar = true;
        options.hidesDefaultSpinner = true;
        options.backButtonFontSize = "14";
        options.textColor = "#FFFFFF";
        options.barBackgroundColor = "#000000";
        // options.browserBackgroundColor = "#000000";

        InAppBrowser.OpenURL(InputFieldScript.input, options);
    }

    public void OnClearCacheClicked()
    {
        InAppBrowser.ClearCache();
    }

    public void BackButton()
    {
        InAppBrowserBridge bridge = FindObjectOfType<InAppBrowserBridge>();
        bridge.onAndroidBackButtonPressed.AddListener(InAppBrowser.GoBack);
    }
}