using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldScript : MonoBehaviour
{
    public static string input;

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }
}