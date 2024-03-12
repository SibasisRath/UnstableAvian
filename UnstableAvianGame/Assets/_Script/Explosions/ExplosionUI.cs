using UnityEngine;
using TMPro;

public class ExplosionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blastWaring;
    private Explosions explosionType;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        blastWaring.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Clamp(timer, 0f, Mathf.Infinity);

        timer -= Time.deltaTime;

        

        if (timer > 0)
        {
            blastWaring.enabled = true;
        }
        else
        {
            blastWaring.enabled = false;
        }

        blastWaring.text = explosionType.ToString() + ":\n" + Mathf.CeilToInt(timer).ToString();
    }
    public void display(Explosions explosions, float seconds)
    {
        explosionType = explosions;
        timer = seconds; 
    }
}
