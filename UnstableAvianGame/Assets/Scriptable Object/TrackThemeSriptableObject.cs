using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TrackTheme")]
public class TrackThemeSriptableObject : ScriptableObject
{
    [SerializeField] private TrackThemesEnum trackTheme;
    [SerializeField] private List<GameObject> trackGameObjects;
    [SerializeField] private List<GameObject> trackThemeObstacles;
    [SerializeField] private GameObject airBoost;

    public TrackThemesEnum TrackThemeName { get => trackTheme; set => trackTheme = value; }
    public List<GameObject> TrackGameObjects { get => trackGameObjects; set => trackGameObjects = value; }
    public List<GameObject> TrackThemeObstacles { get => trackThemeObstacles; set => trackThemeObstacles = value; }
    public GameObject AirBoost { get => airBoost; set => airBoost = value; }
}
