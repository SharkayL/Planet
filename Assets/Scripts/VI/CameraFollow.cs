using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,player.position,smoothSpeed * Time.deltaTime);
    }
}
