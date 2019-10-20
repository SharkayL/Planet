using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    float radius;
    float x;
    float y;
    float step = 10;
    Rigidbody planet;
    // Start is called before the first frame update
    void Start()
    {
        radius = this.GetComponent<SphereCollider>().radius;
        planet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("LeftX");
        y = Input.GetAxis("LeftY");
        //Debug.Log("x"+x+"y"+y);
        Quaternion toRotation = Quaternion.Euler(x, 0, -y);
        planet.angularVelocity = new Vector3(x, 0, -y)*(Mathf.PI/2)*step*Time.deltaTime;
        //transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * toRotation, step * Time.deltaTime);
    }
}
