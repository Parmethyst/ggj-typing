using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pantun", menuName = "ScriptableObjects/PantunScriptableObject", order = 1)]
public class Pantun :ScriptableObject {
    [TextArea]
    public string content;
}