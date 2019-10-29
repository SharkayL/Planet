using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    public bool launch = false;
    Vector3 dir;
    PlanetPhysics planet;
    Rigidbody rocketBody;
    float force = 50;
    // Start is called before the first frame update
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        rocketBody = GetComponent<Rigidbody>();
        dir = Vector3.Normalize(transform.position - planet.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (launch) {
            //get the player;
            rocketBody.AddForce(dir*force, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collectable") {
            launch = true;
        }
    }
}
