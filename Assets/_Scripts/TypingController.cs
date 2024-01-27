using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class TypingController : MonoBehaviour
{
    [SerializeField] List<string> textsToType;
    [SerializeField] TextMeshProUGUI guideText;
    [SerializeField] TextMeshProUGUI inputText;
    private string playerString = "";
    private string currentString = "";
    private string typedString = "";
    private string currentIdx = "";
    private List<string> slicedWords;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        inputText.text = typedString + playerString;
    }
    void HandleInput()
    {
        if (Input.GetKey(KeyCode.Delete)) return;
        foreach (char c in Input.inputString)
        {
            if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z') // has backspace/delete been pressed?
            {
                playerString += c;
            }
            else if (c == '\b')
            {
                if (playerString.Length != 0)
                {
                    playerString = playerString.Substring(0, playerString.Length - 1);
                }
            }
            else if (c == ' ')
            {
                typedString += "<color=\"red\">" + string.Copy(playerString) + "</color>" + " ";
                playerString = "";
            }
        }
    }
}
