using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private List<TrackThemeSriptableObject> trackThemeSriptableObjects;
    private DifficultyModeScriptableObject currentDifficultyMode;

    private int trackCounter = 0;

    //The tuning of the game has been done and these constants are figured out.
    private const int obstacleSpawnLocationWidthFactor = 5;
    private const int obstacleSpawnLocationLengthFactor = 5;
    private const int airBoostSpawnLocationWidthFactor = 2;
    private const int airBoostSpawnLocationLengthFactor = 5;
    private const int airBoostSpawnLowerLimitY = 16;
    private const int airBoostSpawnUpperLimitY = 40;
    private TrackThemeSriptableObject currentTrackTheme;
    private GameObject track;

    private GameManagerScript gameManagerScript;
    

    private void Start()
    {
        currentTrackTheme = trackThemeSriptableObjects[0];
        gameManagerScript = GameManagerScript.Instance;
    }

    public void GeneratingTrack()
    {
        currentDifficultyMode = gameManagerScript.GetCurrentDifficultyModeInfo();

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

    public void GenerateAirBoosts(GameObject track)
    {
        for (int i = 0; i < currentDifficultyMode.PowerBoosts; i++) //here this 3 will be changed according to the difficulty level
        {
            GameObject airBoost = GameObject.Instantiate(currentTrackTheme.AirBoost);
            airBoost.transform.position = GetRandomAirBoostLocation(track);
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
        float trackWidth = track.transform.localScale.x * obstacleSpawnLocationWidthFactor;
        float trackLength = track.transform.localScale.z * obstacleSpawnLocationLengthFactor;
        Vector3 obstaclePosition = track.transform.position + new Vector3(Random.Range(-trackWidth, trackWidth), Random.Range(0, obstacle.transform.localScale.y/4), Random.Range(-trackLength, trackLength));
        return obstaclePosition;
    }

    private Vector3 GetRandomAirBoostLocation(GameObject track)
    {
        float trackWidth = track.transform.localScale.x * airBoostSpawnLocationWidthFactor;
        float trackLength = track.transform.localScale.z * airBoostSpawnLocationLengthFactor;
        Vector3 obstaclePosition = track.transform.position + new Vector3(Random.Range(-trackWidth, trackWidth), Random.Range(airBoostSpawnLowerLimitY, airBoostSpawnUpperLimitY), Random.Range(-trackLength, trackLength));
        return obstaclePosition;
    }

}
