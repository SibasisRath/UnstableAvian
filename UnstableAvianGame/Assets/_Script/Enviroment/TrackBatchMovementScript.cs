using UnityEngine;

public class TrackBatchMovementScript : MonoBehaviour
{
    [SerializeField] private TrackThemesEnum trackTheme;
    [SerializeField] private float speed;

    private GameManagerScript gameManagerScript;

    public TrackThemesEnum TrackTheme { get => trackTheme; set => trackTheme = value; }

    private void Start()
    {
        gameManagerScript = GameManagerScript.Instance;
    }

    void Update()
    {
        speed = gameManagerScript.GetCurrentDifficultyModeInfo().Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}
