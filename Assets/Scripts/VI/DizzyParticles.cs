﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyParticles : MonoBehaviour
{
    float timer = 2f;
    [SerializeField]float currentTimer;

    private void OnEnable()
    {
        GetComponentInParent<PlayerMovementScript>().enabled = false;
    }

    private void Update()
    {

        transform.Rotate(0, 10, 0);
        if (currentTimer < timer)
        {
            currentTimer += Time.deltaTime;
        }
        else {
            currentTimer = 0;
            GetComponentInParent<PlayerMovementScript>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}