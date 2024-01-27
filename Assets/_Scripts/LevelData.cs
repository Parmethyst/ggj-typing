using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
    [SerializeField] private int timer;
    [SerializeField] private int enemyDamage;
    [SerializeField] private List<Pantun> pantuns;
    public int Timer{get {return timer;} set {timer=value;}}
    public int EnemyDamage{get{return enemyDamage;} set {enemyDamage=value;}}
    public List<Pantun> Pantuns {get {return pantuns;} set{pantuns=value;}}
}