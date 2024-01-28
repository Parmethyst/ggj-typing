using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] List<LevelData> levels;
    [SerializeField] SpriteRenderer backgroundSprite;
    [SerializeField] List<Story> stories;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] StoryController storyController;
    [SerializeField] TypingController typingController;
    [SerializeField] Image playerHpBar;
    [SerializeField] Image enemyHpBar;
    [SerializeField] Image enemyProfpic;
    [SerializeField] Animator pitungAnimator;
    [SerializeField] Animator enemyAnimator;
    [SerializeField] CanvasGroup winScreenGroup;
    [SerializeField] CanvasGroup loseScreenGroup;
    [SerializeField] Button nextButton;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [SerializeField] Camera cam;
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
        storyController.Initialize(stories[0]);
    }
    void Update()
    {
        if (!gameStarted) return;
        currentTimer -= Time.deltaTime;
        timerText.text = currentTimer.ToString("F0");
    }
    public void HurtPlayer()
    {
        currentPlayerHp -= levels[currentLevel].EnemyDamage;
        playerHpBar.fillAmount = (float)currentPlayerHp / maxHp;
        pitungAnimator.SetTrigger("IsAttacked");
        PlaySFX(levels[currentLevel].EnemyAttackSfx);
        Tween.ShakeCamera(cam, strengthFactor: 1.0f, duration: 0.5f, frequency: 10);
        if(currentPlayerHp<=0) {
            ShowGameOverScreen();
        }
    }
    public void HurtEnemy()
    {
        currentEnemyHp -= 100 / levels[currentLevel].Pantuns.Count;
        enemyHpBar.fillAmount = (float)currentEnemyHp / maxHp;
        enemyAnimator.SetTrigger("IsAttacked");
        PlaySFX(levels[currentLevel].PlayerAttackSfx);
        Tween.ShakeCamera(cam, strengthFactor: 1.0f, duration: 0.5f, frequency: 10);
    }
    public void NextLevel()
    {
        Utility.FadeDisableCanvasGroup(winScreenGroup,0.5f,1);
        enemyAnimator.gameObject.SetActive(false);
        currentLevel++;
        LoadLevel(currentLevel);
    }
    public void StartGameplay() {
        LoadLevel(0);
    }
    public void LoadLevel(int levelIdx) {
        enemyAnimator=levels[currentLevel].EnemyAnimator;
        enemyAnimator.gameObject.SetActive(true);
        currentEnemyHp = maxHp;
        currentPlayerHp = maxHp;
        playerHpBar.fillAmount = (float)currentPlayerHp / maxHp;
        enemyHpBar.fillAmount = (float)currentEnemyHp / maxHp;
        currentTimer = levels[currentLevel].Timer;
        timerText.text = currentTimer.ToString("F0");
        backgroundSprite.sprite=levels[currentLevel].Background;
        enemyProfpic.sprite=levels[currentLevel].EnemyProfile;
        typingController.GetNewLevelContent();
        bgmAudioSource.clip=levels[currentLevel].Bgm;
        bgmAudioSource.Play();
        Tween.Delay(0.5f,()=>{gameStarted=true;});
    }
    public void ShowWinScreen() {
        gameStarted=false;
        if (currentLevel >= levels.Count-1){
            storyController.Initialize(stories[1]);
            nextButton.gameObject.SetActive(false);
            Utility.EnableMenu(winScreenGroup);
        }
        else {
            Utility.FadeEnableCanvasGroup(winScreenGroup,0.5f,1);
        }
        timeLeftText.text=Mathf.FloorToInt(levels[currentLevel].Timer-currentTimer).ToString() + "s";
    }
    public void ShowGameOverScreen() {
        typingController.ResetTextContents();
        gameStarted=false;
        Utility.EnableMenu(loseScreenGroup);
    }
    public void RestartLevel() {
        LoadLevel(currentLevel);
        Utility.FadeDisableCanvasGroup(loseScreenGroup,0.5f,1);
    }
    public void PlaySFX(AudioClip clip) {
        if(sfxAudioSource.isPlaying) sfxAudioSource.Stop();
        sfxAudioSource.clip=clip;
        sfxAudioSource.Play();
    }
    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
