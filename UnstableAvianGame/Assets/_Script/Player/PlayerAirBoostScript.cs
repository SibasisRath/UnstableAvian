using UnityEngine;
using TMPro;
public class PlayerAirBoostScript : MonoBehaviour
{
    private static int height = 0;
    [SerializeField] private int additionalHeightPerAirBoost = 4;
    [SerializeField] private TextMeshProUGUI airBoostText;

   public void IncreaseingHeight()
    {
        height += additionalHeightPerAirBoost;
    }

    public void ResetingHeight() 
    {
        height = 0;
    }

    public int GetHeight()
    {
        return height;
    }

    private void Start()
    {
        height = 0;
        airBoostText.text = $"Jump Force:\n{height}";
    }

    private void Update()
    {
        airBoostText.text = $"Jump Force:\n{height}";
    }


}
