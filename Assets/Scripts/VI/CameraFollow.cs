using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    public float smoothSpeed = 5;

    void Update()
    {
        foreach (var target in FindObjectsOfType<PlayerMovementScript>())
        {
            if (target.enabled) {
                player = target.transform;
            }
        }
        transform.position = Vector3.Lerp(transform.position,player.position,smoothSpeed * Time.deltaTime);
    }
}
