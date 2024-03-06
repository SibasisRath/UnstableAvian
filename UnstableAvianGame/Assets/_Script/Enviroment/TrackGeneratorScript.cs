using System.Collections.Generic;
using UnityEngine;

public class TrackGeneratorScript
{
    private int obstaclesAmount = 4;
    private int airBoostAmount = 3;
    private TrackThemeSriptableObject trackThemeSO;
    GameObject track;

   public List<GameObject> TrackGeneration(TrackThemeSriptableObject trackThemeSriptableObject, Transform transform)
    {
        trackThemeSO = trackThemeSriptableObject;

        List<GameObject> tracks = new List<GameObject>();


        for (int i = 0; i < 4; i++) //here this 4 will be changed according to the difficulty level
        {

            track = GameObject.Instantiate(trackThemeSO.TrackGameObjects[(int)Random.Range(0, trackThemeSO.TrackGameObjects.Count)]);
            
            track.transform.parent = transform;
            track.SetActive(false);
            tracks.Add(track);
            
        }
        return tracks;
    }

    public void GenerateAirBoosts(GameObject track, Transform spawnLocationTransform)
    {
        for (int i = 0; i < airBoostAmount; i++) //here this 3 will be changed according to the difficulty level
        {
            GameObject airBoost = GameObject.Instantiate(trackThemeSO.AirBoost);
            airBoost.transform.position = GetRandomLocation(track, spawnLocationTransform);
            airBoost.transform.parent = track.transform;
        }
    }

    public void GenerateObstacle(GameObject track, Transform spawnLocationTransform, TrackThemeSriptableObject trackThemeSriptableObject)
    {
        trackThemeSO = trackThemeSriptableObject;
        for (int i = 0; i < obstaclesAmount; i++) //here this 4 will be changed according to the difficulty level
        {
            GameObject obstacle = GameObject.Instantiate(trackThemeSO.TrackThemeObstacles[(int)Random.Range(0, trackThemeSO.TrackThemeObstacles.Count)]);
            obstacle.transform.position = GetRandomLocation(track, spawnLocationTransform);
            obstacle.transform.parent = track.transform;
        }
    }


    private Vector3 GetRandomLocation(GameObject track,Transform spawnLocationTransform)
    {
        float trackWidth = 50;
        float trackLength = 80;
        Vector3 obstaclePosition = new Vector3( Random.Range(-trackWidth, trackWidth), spawnLocationTransform.position.y + Random.Range(10, 60),  Random.Range(-trackLength, trackLength));
        return obstaclePosition;
    }
}
