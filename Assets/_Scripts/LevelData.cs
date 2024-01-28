using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
    [SerializeField] private int timer;
    [SerializeField] private int enemyDamage;
    [SerializeField] private List<Pantun> pantuns;
    [SerializeField] private Sprite background;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Sprite enemyProfile;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip playerAttackSfx;
    [SerializeField] private AudioClip enemyAttackSfx;
    public int Timer{get {return timer;} set {timer=value;}}
    public int EnemyDamage{get{return enemyDamage;} set {enemyDamage=value;}}
    public List<Pantun> Pantuns {get {return pantuns;} set{pantuns=value;}}
    public Sprite Background { get => background; set => background = value; }
    public AudioClip Bgm { get => bgm; set => bgm = value; }
    public AudioClip PlayerAttackSfx { get => playerAttackSfx; set => playerAttackSfx = value; }
    public AudioClip EnemyAttackSfx { get => enemyAttackSfx; set => enemyAttackSfx = value; }
    public Animator EnemyAnimator { get => enemyAnimator; set => enemyAnimator = value; }
    public Sprite EnemyProfile { get => enemyProfile; set => enemyProfile = value; }
}