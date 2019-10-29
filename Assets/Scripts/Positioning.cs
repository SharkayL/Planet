using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    Vector3 pos;
    Vector3 oriPos;
    PlanetPhysics planet;
    // Start is called before the first frame update
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        oriPos = this.transform.position;
        Vector3 v = this.transform.position - planet.transform.position;
        transform.up = v.normalized;
        pos = Vector3.Normalize(v) * (planet.radius);
        transform.position = this.planet.transform.position  + pos;
    }

}
