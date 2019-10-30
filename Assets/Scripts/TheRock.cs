using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRock : MonoBehaviour
{
    PlanetPhysics planet;

    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        Vector3 oriPos = this.transform.position;
        Vector3 v = this.transform.position - planet.transform.position;
        transform.up = v.normalized;
        Vector3 pos = Vector3.Normalize(v) * (planet.radius);
        transform.position = this.planet.transform.position + pos;
    }


    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.name == "Plane") {
            this.transform.up = other.gameObject.transform.parent.transform.up;
            this.transform.SetParent(other.gameObject.transform.parent.transform);
            transform.localPosition = new Vector3(0, 0.4f, -0.2f);           
        }
    }
}
