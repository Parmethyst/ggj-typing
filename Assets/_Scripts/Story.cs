using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story", menuName = "ScriptableObjects/StoryScriptableObject", order = 2)]
public class Story : ScriptableObject
{
    public List<string> dialogues;
    public List<Sprite> cutscenes;
}
