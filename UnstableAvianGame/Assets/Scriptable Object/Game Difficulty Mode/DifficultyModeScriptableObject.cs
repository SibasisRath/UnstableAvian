using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/DifficultyMode")]
public class DifficultyModeScriptableObject : ScriptableObject
{
    [SerializeField] private DifficultyMode difficultyMode;
    [SerializeField] private float speed;
    [SerializeField] private int powerBoosts;
    [SerializeField] private int Obstacles;

    public DifficultyMode DifficultyMode { get => difficultyMode; set => difficultyMode = value; }
    public float Speed { get => speed; set => speed = value; }
    public int PowerBoosts { get => powerBoosts; set => powerBoosts = value; }
    public int Obstacles1 { get => Obstacles; set => Obstacles = value; }
}
