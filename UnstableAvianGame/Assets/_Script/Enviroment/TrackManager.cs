using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private List<TrackThemeSriptableObject> trackThemeSriptableObjects;
    private DifficultyModeScriptableObject currentDifficultyMode;

    private int trackCounter = 0;


    private const int totalNumberOfTracks = 4; //Right Now I am keeping this constant But we can make it flexible according to the difficulty modes.
    private TrackThemeSriptableObject currentTrackTheme;
    GameObject track;

    private void Start()
    {
        currentTrackTheme = trackThemeSriptableObjects[0];
    }

    private void Update()
    {
        currentDifficultyMode = GameManagerScript.Instance.GetCurrentDifficultyModeInfo();
    }

    public void GeneratingTrack()
    {
        if (trackCounter > currentDifficultyMode.ThemeLength)
        {
            trackCounter = 0;

            if (trackThemeSriptableObjects.IndexOf(currentTrackTheme) == trackThemeSriptableObjects.Count-1)
            {
                currentTrackTheme = trackThemeSriptableObjects[0];
            }
            else
            {
                currentTrackTheme = trackThemeSriptableObjects[trackThemeSriptableObjects.IndexOf(currentTrackTheme)+1];
            }
            
        }


        track = GameObject.Instantiate(currentTrackTheme.TrackGameObjects[(int)Random.Range(0, currentTrackTheme.TrackGameObjects.Count)], transform);
        trackCounter++;

        track.transform.parent = transform;
        GenerateAirBoosts(track);
        GenerateObstacle(track);
    }

    private TrackThemeSriptableObject GetTrackThemeSriptableObject(TrackThemesEnum trackTheme)
    {
        TrackThemeSriptableObject resultTheme = null;

        foreach (TrackThemeSriptableObject theme in trackThemeSriptableObjects )
        {
            if (theme.TrackThemeName == trackTheme)
            {
                resultTheme = theme;
            }
        }
        return resultTheme;
    }

    public void GenerateAirBoosts(GameObject track)
    {
        for (int i = 0; i < currentDifficultyMode.PowerBoosts; i++) //here this 3 will be changed according to the difficulty level
        {
            GameObject airBoost = GameObject.Instantiate(currentTrackTheme.AirBoost);
            airBoost.transform.position = GetRandomAriBoostLocation(track);
            airBoost.transform.parent = track.transform;
        }
    }

    public void GenerateObstacle(GameObject track)
    {
        for (int i = 0; i < currentDifficultyMode.Obstacles; i++) //here this 4 will be changed according to the difficulty level
        {
            GameObject obstacle = GameObject.Instantiate(currentTrackTheme.TrackThemeObstacles[(int)Random.Range(0, currentTrackTheme.TrackThemeObstacles.Count)]);
            obstacle.transform.position = GetRandomObstaclePosition(track, obstacle);
            obstacle.transform.parent = track.transform;
        }
    }


    private Vector3 GetRandomObstaclePosition(GameObject track, GameObject obstacle)
    {
        float trackWidth = track.transform.localScale.x * 5;
        float trackLength = track.transform.localScale.z * 5;
        Vector3 obstaclePosition = track.transform.position + new Vector3(Random.Range(-trackWidth, trackWidth), Random.Range(0, obstacle.transform.localScale.y/4), Random.Range(-trackLength, trackLength));
        return obstaclePosition;
    }

    private Vector3 GetRandomAriBoostLocation(GameObject track)
    {
        float trackWidth = track.transform.localScale.x * 2;
        float trackLength = track.transform.localScale.z * 5;
        Vector3 obstaclePosition = track.transform.position + new Vector3(Random.Range(-trackWidth, trackWidth), Random.Range(16, 40), Random.Range(-trackLength, trackLength));
        return obstaclePosition;
    }

}
