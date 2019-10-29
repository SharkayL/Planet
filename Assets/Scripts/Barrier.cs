using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//untested;
public class Barrier : MonoBehaviour
{
    Rigidbody barrier;
    float timer;
    bool timing = false;
    GameObject forbiddenSign;
    PlanetPhysics planet;
    // Start is called before the first frame update
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        barrier = GetComponent<Rigidbody>();
        forbiddenSign = GetComponentInChildren<Sign>().gameObject;
        forbiddenSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timing) {
            timer += Time.deltaTime;
            if (timer > 3) {
                forbiddenSign.SetActive(false);
                timing = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dog" || other.gameObject.name == "Kangaroo") {
            timing = true;
            forbiddenSign.SetActive(true);
            forbiddenSign.transform.position = other.gameObject.transform.position + Vector3.Normalize(barrier.worldCenterOfMass - other.gameObject.transform.position);
            Vector3 normal = (forbiddenSign.transform.position - planet.transform.position).normalized;
            forbiddenSign.transform.rotation = Quaternion.LookRotation((other.gameObject.transform.position - forbiddenSign.transform.position), normal);
            //push collider objects back
        }
    }
}
