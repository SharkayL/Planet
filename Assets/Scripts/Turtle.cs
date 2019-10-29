using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public bool beingGrabed = false;
    float timer;
    bool timing = false;
    public GameObject theBird;
    bool beingReleased = false;
    bool landing = false;
    Vector3 dir;
    PlanetPhysics planet;
    float speed = 8;
    private void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
    }
    // Update is called once per frame
    void Update()
    {
        if (beingGrabed) {
            transform.SetParent(theBird.transform);
            beingGrabed = false;
            timing = true;
        }
        if (timing) {
            timer += Time.deltaTime;
            if (timer >= 7) {
                beingReleased = true;
                timing = false;
            }
        }
        if (beingReleased)
        {
            transform.SetParent(null);
            landing = true;
            dir = (planet.transform.position - this.transform.position).normalized;
        }
    }
    private void FixedUpdate()
    {
        if (landing) {
            float distance = Vector3.Distance(planet.transform.position, this.transform.position);
            if (distance > planet.radius)
            {
                transform.position += dir * speed * Time.deltaTime;
            }
            else {
                Vector3 normal = -dir;
                transform.up = normal;
                transform.position = this.planet.transform.position + normal * (planet.radius);
                landing = false;
            }
        }
    }

}
