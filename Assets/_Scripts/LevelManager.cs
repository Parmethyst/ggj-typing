using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] List<LevelData> levels;
    [SerializeField] Slider playerHpBar;
    [SerializeField] Slider enemyHpBar;
    private int currentLevel=0;
    private float currentTimer=0.0f;
    private int currentPlayerHp=100;
    private int currentEnemyHp=100;
    private int maxHp=100;
    void Start() {
        currentTimer=levels[0].Timer/1.0f;
        playerHpBar.value=currentPlayerHp;
        enemyHpBar.value=currentEnemyHp;
    }
    void Update(){
        currentTimer-=Time.deltaTime;
        timerText.text=currentTimer.ToString();
    }
    public void HurtPlayer() {
        currentPlayerHp-=levels[currentLevel].EnemyDamage;
        playerHpBar.value=currentPlayerHp;
    }
    public void HurtEnemy() {
        currentEnemyHp-=Mathf.FloorToInt(100/levels[currentLevel].Pantuns.Count);
        enemyHpBar.value=currentEnemyHp;
    }
    public void NextLevel() {
        currentLevel++;
        currentEnemyHp=maxHp;
        currentPlayerHp=maxHp;
        playerHpBar.value=currentPlayerHp;
        enemyHpBar.value=currentEnemyHp;
        currentTimer=levels[currentLevel].Timer;
    }
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public List<LevelData> Levels { get => levels; set => levels = value; }
}
