using System.Collections;
using UnityEngine;
using TMPro;

public class ExplosionManager : MonoBehaviour
{
    [Tooltip("If base explosion damage is 'x'. It means in the case of big explosion the outter circle will do this much damage, middle circle will do 2x amount and the inner circle will do 3x amount of damage.")]
    [SerializeField] private int baseExplosionDamage = 2;
    private static int totalExplosionAmount;
    [Tooltip("This is the max limit of destruction that can be done to environment. After crossing this limit game over.")]
    [SerializeField] private int totalPossibleDestrutionAmount;

    [SerializeField] private GameObject parent;
    [SerializeField] private LayerMask obstacle;
    [SerializeField] private float smallExplosionRange;
    [SerializeField] private float midExplosionRange;
    [SerializeField] private float bigExplosionRange;
    [SerializeField] private float explosionWarningDelay = 3f;
    [SerializeField] private float explosionGap = 15f;
    [SerializeField] private ExplosionUI explosionUI;
    private Explosions explosionType;

    [SerializeField] private float jumpDuration = 1f;

    [SerializeField] private PlayerAirBoostScript playerAirBoostScript;

    [SerializeField] private PlayerStateManager playerStateManager;

    [SerializeField] private TextMeshProUGUI totalDamageText;


    // Start is called before the first frame update
    void Start()
    {
        totalExplosionAmount = 0;
        totalDamageText.text = $"Destruction:\n{totalExplosionAmount}/{totalPossibleDestrutionAmount}";
        InvokeRepeating(nameof(ExplosionProcess), explosionGap, explosionGap);
    }

    public void ExplosionProcess()
    {
        playerStateManager.PlayerState = PlayerStates.Exploding;
        explosionType = RandomExplosionGenerator();
        explosionUI.ShowExplosionWarning(explosionType, explosionWarningDelay);
        StartCoroutine(Explode());
    }

    private Explosions RandomExplosionGenerator()
    {
        const int lowestNumber = 1;
        const int highestNumber = 100;
        const int smallExplosionNumber = (int)(highestNumber / 2);
        const int middleExplosionNumber = (int)(highestNumber* (4 / 5));

        int randomExplosionNumber = (int)(Random.Range(lowestNumber,highestNumber));
        Explosions explosionType;

        if (randomExplosionNumber < highestNumber/2)
        {
            explosionType = Explosions.Small;
        }
        else if (randomExplosionNumber > smallExplosionNumber && randomExplosionNumber < middleExplosionNumber)
        {
            explosionType = Explosions.Medium;
        }
        else
        {
            explosionType = Explosions.Big;
        }
        return explosionType;
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionWarningDelay);

        if (playerStateManager.PlayerState == PlayerStates.Exploding)
        {
            int totalDamage = ExplosionDamageCalculation(explosionType);
        }
    }

    private int ExplosionDamageCalculation(Explosions explosion)
    {
        int totalDamage = 0;
        RaycastHit hit = new RaycastHit();

        if (explosion == Explosions.Big && Physics.Raycast(transform.position, Vector3.down, out hit, bigExplosionRange, obstacle))
        {
            totalDamage += baseExplosionDamage;
            explosion = Explosions.Medium;

        }


        if (explosion == Explosions.Medium && Physics.Raycast(transform.position, Vector3.down, out hit, midExplosionRange, obstacle))
        {
            totalDamage += baseExplosionDamage;
            explosion = Explosions.Small;

        }


        if (explosion == Explosions.Small && Physics.Raycast(transform.position, Vector3.down, out hit, smallExplosionRange, obstacle))
        {
            totalDamage += baseExplosionDamage;

        }
        totalExplosionAmount += totalDamage;
        

        if (totalPossibleDestrutionAmount <= totalExplosionAmount)
        {
            GameManagerScript.Instance.GameState = GameStates.Over;
        }

        totalDamageText.text = $"Destruction:\n{totalExplosionAmount}/{totalPossibleDestrutionAmount}";

        playerStateManager.PlayerState = PlayerStates.Alive; //From player state exploding to player state alive

        return totalDamage;
    }

    public void JumpAndExplode()
    {
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        Vector3 positionBeforeJump = parent.transform.position;
        Vector3 positionAfterJump = parent.transform.position + new Vector3(0, playerAirBoostScript.GetHeight(), 0); // Adjust the jump height as needed

        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;
            parent.transform.position = Vector3.Lerp(positionBeforeJump, positionAfterJump, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the jump ends exactly at positionAfterJump
        parent.transform.position = positionAfterJump;

        ExplosionDamageCalculation(explosionType);

        // Perform the explosion
        yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds for the explosion to occur

        // Move back to the original position
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;
            parent.transform.position = Vector3.Lerp(positionAfterJump, positionBeforeJump, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the parent ends up exactly at positionBeforeJump
        parent.transform.position = positionBeforeJump;

        // Set the player state back to Alive
        playerStateManager.PlayerState = PlayerStates.Alive;
        playerAirBoostScript.ResetHeight();
    }
}
