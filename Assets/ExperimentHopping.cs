using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentHopping : MonoBehaviour
{
    Rigidbody foxBody;
    Vector3 normal;
    PlanetPhysics planet;
    float g = 9.0f;
    Vector3 orig;
    Vector3 hoppingDir;
    public float hoppingForce = 20f;
    public bool onGround;

    
    // Start is called before the first frame update
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        orig = planet.transform.position;
        foxBody = GetComponent<Rigidbody>();
        hoppingDir = new Vector3(0, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        normal = Vector3.Normalize(transform.position - planet.transform.position);

        Vector3 baseCross = Vector3.Cross(transform.forward, normal);
        Vector3 forward = Vector3.Cross(normal, baseCross);
        this.transform.rotation = Quaternion.LookRotation(forward, normal);
    }

    private void FixedUpdate()
    {
        if (GroundCheck())
        {
            onGround = true;
            Quaternion forceOrientation = Quaternion.LookRotation(transform.forward, normal);
            foxBody.AddForce(forceOrientation * hoppingDir * hoppingForce, ForceMode.Impulse);

        }
        else {
            onGround = false;
        foxBody.AddForce(-normal * g, ForceMode.Acceleration);

        }
    }

    bool GroundCheck() {
        RaycastHit hitinfo;
        Vector3 center = foxBody.worldCenterOfMass;
        if (Physics.Raycast(center, -normal, out hitinfo, 0.5f))
        {
            Debug.DrawLine(center, hitinfo.point);
            if (hitinfo.collider.gameObject.GetComponent<PlanetPhysics>())
            {
                return true;
            }

            else return false;
        }
        return false;
    }
}
