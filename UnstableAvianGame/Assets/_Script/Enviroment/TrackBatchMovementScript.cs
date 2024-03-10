using UnityEngine;

public class TrackBatchMovementScript : MonoBehaviour
{
    [SerializeField] private TrackThemesEnum trackTheme;
    [SerializeField] private float speed;

    public TrackThemesEnum TrackTheme { get => trackTheme; set => trackTheme = value; }

    // Update is called once per frame
    void Update()
    {
        speed = GameManagerScript.Instance.GetCurrentDifficultyModeInfo().Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}
