using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TypingController : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] TextMeshProUGUI guideText;
    [SerializeField] TextMeshProUGUI inputText;
    private string playerString = "";
    private string typedString = "";
    private int currentPantunIdx=0;
    private int currentLineIdx=0;
    private int currentWordIdx = 0;
    private List<string> slicedWords;
    private List<string> slicedContents;
    void Start()
    {
        GetNewLevelContent();
    }
    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if(levelManager.CurrentLevel>=levelManager.Levels.Count) return;
        if (Input.GetKey(KeyCode.Delete)) return;
        foreach (char c in Input.inputString)
        {
            if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c==',' || c=='!')
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
            else if (c == ' ' || c=='\n' || c=='\r')
            {
                if(playerString.Equals(slicedWords[currentWordIdx])) {
                    typedString+="<color=\"green\">"+string.Copy(playerString) + "</color>" + " ";
                }
                else {
                    typedString += "<color=\"red\">"+string.Copy(slicedWords[currentWordIdx]) + "</color>" + " "; 
                }
                currentWordIdx++;
                if(currentWordIdx==slicedWords.Count()) {
                    typedString+="\n";
                    currentLineIdx++;
                    Debug.Log(currentLineIdx);
                    currentWordIdx=0;
                    if(currentLineIdx!=4) GetNextLineWords();
                    if(currentLineIdx==2) {
                        ShowNextPair(currentLineIdx);
                    }
                    else if(currentLineIdx==4) {
                        bool isLastPantunInLevel=currentPantunIdx==levelManager.Levels[levelManager.CurrentLevel].Pantuns.Count-1;
                        if(isLastPantunInLevel) {
                            levelManager.CurrentLevel++;
                            GetNewLevelContent();
                        }
                        else {
                            currentPantunIdx++;
                            GetNextEnemy();
                        }
                    }
                }
                playerString = "";
                
            }
            inputText.text = typedString + playerString;
        }
    }
    public void GetNewLevelContent() {
        if(levelManager.CurrentLevel==levelManager.Levels.Count) return;
        currentPantunIdx=0;
        GetNextEnemy();
    }
    public void GetNextEnemy() {
        currentLineIdx=0;
        currentWordIdx=0;
        slicedContents = new List<string>(levelManager.Levels[levelManager.CurrentLevel].Pantuns[currentPantunIdx].content.Split(
            new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        ));
        GetNextLineWords();
        ShowNextPair(currentLineIdx);
    }
    public void GetNextLineWords() {
        slicedWords = new List<string>(slicedContents[currentLineIdx].Split(" ",StringSplitOptions.None));
    }
    public void ShowNextPair(int startIndex) {
        typedString="";
        guideText.text=slicedContents[startIndex]+"\n" + slicedContents[startIndex+1];
    }
}
