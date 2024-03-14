using UnityEngine;
using TMPro;
public class PlayerAirBoostScript : MonoBehaviour
{
    private int height = 0;
    [SerializeField] private int additionalHeightPerAirBoost = 4;
    [SerializeField] private TextMeshProUGUI airBoostText;


    private void Start()
    {
        ResetHeight();
    }

    public void IncreaseHeight()
    {
        height += additionalHeightPerAirBoost;
        UpdateHeightText();
    }

    public void ResetHeight() 
    {
        height = 0;
        UpdateHeightText();
    }

    public int GetHeight()
    {
        return height;
    }

    private void UpdateHeightText()
    {
        airBoostText.text = $"Jump Force:\n{height}";
    }
}
