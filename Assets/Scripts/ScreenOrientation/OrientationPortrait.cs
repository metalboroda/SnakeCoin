using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationPortrait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
