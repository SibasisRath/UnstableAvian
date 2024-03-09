using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneScript : MonoBehaviour
{
    [SerializeField] private TrackManager trackManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Debug.Log("track destroyed.");
            trackManager.GeneratingTrack();
        }
       
    }
}
