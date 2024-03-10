using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private int playerLivesCount = 3;
    [SerializeField] private TextMeshProUGUI livesLeft;


    private void Start()
    {
        livesLeft.text = $"Life: {playerLivesCount}";
    }
    public int PlayerLivesCount 
    {
        get => playerLivesCount;
        set 
        {
            playerLivesCount = value;
            livesLeft.text = $"Life: {playerLivesCount}";

            if (playerLivesCount <= 0 )
            {
                GameManagerScript.Instance.GameState = GameStates.Over;
            }
        }
    }

}
