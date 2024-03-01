using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"player collided with {collision.gameObject.name}");
    }
}
