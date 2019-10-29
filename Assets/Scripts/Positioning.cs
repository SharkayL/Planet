using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Positioning : MonoBehaviour
{
    Vector3 pos;
    Vector3 oriPos;
    PlanetPhysics planet;
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        oriPos = this.transform.position;
        Vector3 v = this.transform.position - planet.transform.position;
        transform.up = v.normalized;
        float dis = Vector3.Distance(this.transform.position, planet.transform.position);
        Vector3 position = Vector3.Normalize(v) * (planet.radius);
        transform.position = this.planet.transform.position + position;
    }

    private void Update()
    {
        //oriPos = this.transform.position;
        //Vector3 v = this.transform.position - planet.transform.position;
        //transform.up = v.normalized;
        //float dis = Vector3.Distance(this.transform.position, planet.transform.position);
        //Vector3 position = Vector3.Normalize(v) * (planet.radius);
        //transform.position = this.planet.transform.position + position;
    }


}
