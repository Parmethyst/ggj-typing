using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<LevelData> levels;
    private int currentLevel=0;
    private int currentHp=100;
    private int maxHp=100;

    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public List<LevelData> Levels { get => levels; set => levels = value; }
}
