using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Rigidbody barrier;
    float timer;
    bool timing = false;
    GameObject forbiddenSign;
    PlanetPhysics planet;
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        barrier = GetComponent<Rigidbody>();
        forbiddenSign = GetComponentInChildren<Sign>().gameObject;
        forbiddenSign.SetActive(false);
    }

    void Update()
    {
        if (timing) {
            timer += Time.deltaTime;
            if (timer > 3) {
                forbiddenSign.SetActive(false);
                timer = 0;
                timing = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog" || other.gameObject.tag == "Kangaroo" || other.gameObject.tag == "Fox") {
            timing = true;
            forbiddenSign.SetActive(true);
            forbiddenSign.transform.position = other.gameObject.transform.position + Vector3.Normalize(barrier.worldCenterOfMass - other.gameObject.transform.position);
            Vector3 normal = (forbiddenSign.transform.position - planet.transform.position).normalized;
            forbiddenSign.transform.rotation = Quaternion.LookRotation((other.gameObject.transform.position - forbiddenSign.transform.position), normal);

            Vector3 backWardPos = other.transform.position + other.transform.TransformDirection(new Vector3(0, 0, -0.5f));
            other.transform.position = backWardPos;
            other.transform.LookAt(-other.transform.forward);
        }
    }
}
