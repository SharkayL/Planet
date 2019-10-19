using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = this.GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
