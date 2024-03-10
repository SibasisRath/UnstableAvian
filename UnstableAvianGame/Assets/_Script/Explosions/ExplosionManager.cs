using System.Collections;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private LayerMask obstacle;
    [SerializeField] private float smallExplosionRange;
    [SerializeField] private float midExplosionRange;
    [SerializeField] private float bigExplosionRange;
    [SerializeField] private int explosionDelay;
    private Explosions explosionType;

    [SerializeField] private PlayerStateManager playerStateManager;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ExplosionProcess), 10, 15);
    }

    public void ExplosionProcess()
    {
        playerStateManager.PlayerState = PlayerStates.Exploding;

        explosionType = RandomExplosionGenerator();
        Debug.Log(explosionType.ToString());
        StartCoroutine(Explode());
    }

    private Explosions RandomExplosionGenerator()
    {
        int randomExplosionNumber = (int)(Random.Range(1,100));
        Explosions explosionType;

        if (randomExplosionNumber<50)
        {
            explosionType = Explosions.Small;
        }
        else if (randomExplosionNumber > 50 && randomExplosionNumber < 80)
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
        yield return new WaitForSeconds(3);

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
            totalDamage += 2;
            explosion = Explosions.Medium;

        }


        if (explosion == Explosions.Medium && Physics.Raycast(transform.position, Vector3.down, out hit, midExplosionRange, obstacle))
        {
            totalDamage += 2;
            explosion = Explosions.Small;

        }


        if (explosion == Explosions.Small && Physics.Raycast(transform.position, Vector3.down, out hit, smallExplosionRange, obstacle))
        {
            totalDamage += 2;

        }
        Debug.Log($"explosion happened.\ntotal damage {totalDamage}");

        playerStateManager.PlayerState = PlayerStates.Alive;
        return totalDamage;
    }

    public void JumpAndExplode()
    {
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        Vector3 positionBeforeJump = parent.transform.position;
        Vector3 positionAfterJump = parent.transform.position + new Vector3(0, 50, 0); // Adjust the jump height as needed

        float elapsedTime = 0f;
        float jumpDuration = 1f; // Adjust the jump duration as needed

        while (elapsedTime < jumpDuration)
        {
            float t = elapsedTime / jumpDuration;
            parent.transform.position = Vector3.Lerp(positionBeforeJump, positionAfterJump, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the jump ends exactly at positionAfterJump
        parent.transform.position = positionAfterJump;
        Debug.Log("reached the height");

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
        Debug.Log("Jump and explosion completed.");
    }
}
