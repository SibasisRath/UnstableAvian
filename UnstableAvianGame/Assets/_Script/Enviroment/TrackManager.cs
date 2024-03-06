using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private List<TrackThemeSriptableObject> trackThemeSriptableObjects;

    private List<GameObject> tracks;
    private TrackGeneratorScript trackGeneratorScript = new TrackGeneratorScript();

    private int trackCounter = 0;


    private void Awake()
    {
        tracks = new List<GameObject>();
        foreach (TrackThemeSriptableObject trackTheme in trackThemeSriptableObjects)
        {
            GameObject trackThemeGameObject = Instantiate(new GameObject(trackTheme.TrackThemeName.ToString()),transform);
            tracks.AddRange(trackGeneratorScript.TrackGeneration(trackTheme, trackThemeGameObject.transform));

            
        }
        Debug.Log("track count:" + tracks.Count );
    }

    public void AcivatingTrack()
    {
        while (true)
        {
            if (trackCounter >= tracks.Count)
            {
                trackCounter = 0;
            }
            if (tracks[trackCounter].activeSelf == true)
            {
                trackCounter++;
            }
            else
            {
                tracks[trackCounter].SetActive(true);
                TrackThemeSriptableObject trackScriptableObject = GetTrackThemeSriptableObject(tracks[trackCounter].GetComponent<TrackBatchMovementScript>().TrackTheme);
                trackGeneratorScript.GenerateObstacle(tracks[trackCounter], transform, trackScriptableObject);
                trackGeneratorScript.GenerateAirBoosts(tracks[trackCounter], transform);
                tracks[trackCounter].transform.position = transform.position;
                break;
            }
        }
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


}
