using System.Collections;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private LayerMask obstacle;
    [SerializeField] private float smallExplosionRange;
    [SerializeField] private float midExplosionRange;
    [SerializeField] private float bigExplosionRange;
    [SerializeField] private int explosionDelay;



    // Start is called before the first frame update
    void Start()
    {


        InvokeRepeating(nameof(ExplosionProcess), 10, 15);
    }

    public void ExplosionProcess()
    {
        Explosions explosionType = RandomExplosionGenerator();
        Debug.Log(explosionType.ToString());
        StartCoroutine(Explode(explosionType));
    }

    private Explosions RandomExplosionGenerator()
    {
        PlayerStateManager.PlayerState = PlayerStates.Exploding;
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

    private IEnumerator Explode(Explosions explosion)
    {
        yield return new WaitForSeconds(3);

        if (PlayerStateManager.PlayerState == PlayerStates.Exploding)
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

        }

      
       
    }
}
