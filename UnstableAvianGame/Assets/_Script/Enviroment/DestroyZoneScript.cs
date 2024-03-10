using UnityEngine;

public class DestroyZoneScript : MonoBehaviour
{
    [SerializeField] private TrackManager trackManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            Destroy(other.gameObject);
            trackManager.GeneratingTrack();
        }
       
    }
}
