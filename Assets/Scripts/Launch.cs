using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    public bool launch = false;
    Vector3 dir;
    PlanetPhysics planet;
    Rigidbody rocketBody;
    float force = 50;
    GameObject turtle;
    public Image gameOverPanel;
    Color color;

    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        rocketBody = GetComponent<Rigidbody>();
        dir = Vector3.Normalize(transform.position - planet.transform.position);
        color = gameOverPanel.color;
    }

    void Update()
    {
        if (launch) {
            //turtle.transform.SetParent(transform);
            if (color.a <= 1)
            {
                color.a += Time.deltaTime * 0.5f;
            }
            else {
                ScenesController.JumpScene(0);
            }

            gameOverPanel.color = color;
            rocketBody.constraints = RigidbodyConstraints.None;
            rocketBody.AddForce(dir*force, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PurpleRock") {
            launch = true;
            turtle = other.gameObject.transform.parent.parent.gameObject;
        }
    }
}
