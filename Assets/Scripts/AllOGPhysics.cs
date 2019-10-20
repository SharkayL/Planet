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
    public void Start()
    {
        
        planet = FindObjectOfType<PlanetPhysics>();
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        normal = (planet.transform.position - this.body.position).normalized;
        body.AddForce(normal, ForceMode.Acceleration);
        //transform.rotation = Quaternion.LookRotation(transform.forward, -normal);
        transform.up = -normal;
        //Debug.DrawLine(this.body.position, this.body.position + -normal);
    }

}
