using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/DifficultyMode")]
public class DifficultyModeScriptableObject : ScriptableObject
{
    [SerializeField] private DifficultyMode difficultyMode;
    [SerializeField] private float speed;
    [SerializeField] private float themeLength;
    [SerializeField] private int powerBoosts;
    [SerializeField] private int obstacles;
    [SerializeField] private float scoreToInitiate;

    public DifficultyMode DifficultyMode { get => difficultyMode; set => difficultyMode = value; }
    public float Speed { get => speed; set => speed = value; }
    public int PowerBoosts { get => powerBoosts; set => powerBoosts = value; }
    public int Obstacles { get => obstacles; set => obstacles = value; }
    public float ThemeLength { get => themeLength; set => themeLength = value; }
    public float ScoreToInitiate { get => scoreToInitiate; set => scoreToInitiate = value; }
}
