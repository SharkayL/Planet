using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOGPhysics : MonoBehaviour
{
    PlanetPhysics planet;
    Rigidbody body;
    Vector3 normal;
    public float accelaration;
    // Start is called before the first frame update
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        normal = this.transform.position - planet.transform.position;
        body.AddForce(-normal, ForceMode.Acceleration);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += -transform.up*accelaration;
        }
    }
}
