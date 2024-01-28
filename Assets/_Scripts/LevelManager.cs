using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] List<LevelData> levels;
    [SerializeField] List<Story> stories;
    [SerializeField] CanvasGroup storyCanvasGroup;
    [SerializeField] Image playerHpBar;
    [SerializeField] Image enemyHpBar;
    [SerializeField] Animator pitungAnimator;
    private int currentLevel = 0;
    private float currentTimer = 0.0f;
    private int currentPlayerHp = 100;
    private int currentEnemyHp = 100;
    private int maxHp = 100;
    private bool gameStarted = false;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public List<LevelData> Levels { get => levels; set => levels = value; }
    public bool GameStarted { get => gameStarted; set => gameStarted = value; }
    void Start()
    {
        Utility.EnableMenu(storyCanvasGroup);
        currentTimer = levels[0].Timer / 1.0f;
        playerHpBar.fillAmount = (float)currentPlayerHp / maxHp;
        enemyHpBar.fillAmount = (float)currentEnemyHp / maxHp;
    }
    void Update()
    {
        if (!gameStarted) return;
        currentTimer -= Time.deltaTime;
        timerText.text = currentTimer.ToString();
    }
    public void HurtPlayer()
    {
        currentPlayerHp -= levels[currentLevel].EnemyDamage;
        playerHpBar.fillAmount = (float)currentPlayerHp / maxHp;
        pitungAnimator.SetTrigger("IsAttacked");
    }
    public void HurtEnemy()
    {
        currentEnemyHp -= 100 / levels[currentLevel].Pantuns.Count;
        enemyHpBar.fillAmount = (float)currentEnemyHp / maxHp;
    }
    public void NextLevel()
    {
        currentLevel++;
        currentEnemyHp = maxHp;
        currentPlayerHp = maxHp;
        playerHpBar.fillAmount = (float)currentPlayerHp / maxHp;
        enemyHpBar.fillAmount = (float)currentEnemyHp / maxHp;
        currentTimer = levels[currentLevel].Timer;
    }

}
