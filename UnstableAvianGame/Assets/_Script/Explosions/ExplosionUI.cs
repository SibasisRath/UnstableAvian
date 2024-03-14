using UnityEngine;
using TMPro;

public class ExplosionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blastWarningText;
    private Explosions explosionType;
    private float timer = 0;
    [SerializeField] private PlayerStateManager playerStateManager;

    // Start is called before the first frame update
    void Start()
    {
        blastWarningText.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer > 0 && playerStateManager.PlayerState == PlayerStates.Exploding)
        {
            blastWarningText.enabled = true;
        }
        else
        {
            blastWarningText.enabled = false;
        }

        blastWarningText.text = explosionType.ToString() + ":\n" + Mathf.CeilToInt(timer).ToString();
    }
    public void ShowExplosionWarning(Explosions explosions, float seconds)
    {
        explosionType = explosions;
        timer = seconds; 
    }
}
