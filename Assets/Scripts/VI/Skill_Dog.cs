using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Dog : MonoBehaviour
{
    public float radius;
    public LayerMask friendMask;
    public float coolDownTimer;
    public GameObject dizzyParticles;
    bool isFinding;
    float currentTimer;



    void Update()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position,radius, friendMask);
        if (collider.Length > 0 && !isFinding)
        {
            SoundManager.PlaySound(SoundManager.SoundEffects.DogBark);
            isFinding = true;
        }
        if (isFinding) {
            ResetBarking();
        }

    }

    void ResetBarking() {
        if (currentTimer < coolDownTimer)
        {
            currentTimer += Time.deltaTime;
        }
        else {
            currentTimer = 0;
            isFinding = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            dizzyParticles.SetActive(true);
            Vector3 backWardPos = transform.position + transform.TransformDirection(new Vector3(0, 0, -1));
            transform.position = backWardPos;
            SoundManager.PlaySound(SoundManager.SoundEffects.DogWhining);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,1,0.3f);
        Gizmos.DrawSphere(transform.position,radius);
    }
}
