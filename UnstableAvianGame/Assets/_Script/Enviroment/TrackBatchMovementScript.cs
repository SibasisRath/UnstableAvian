using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBatchMovementScript : MonoBehaviour
{
    [SerializeField] private TrackThemesEnum trackTheme;
    [SerializeField] private float speed = 50; // this will be later change and adjucted as difficulty level.

    public TrackThemesEnum TrackTheme { get => trackTheme; set => trackTheme = value; }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}
