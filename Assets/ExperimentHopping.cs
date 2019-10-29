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
    public float groundCheckDis = 0.5f;
    public bool onGround;

    public float radius;
    public LayerMask kangarooMask;
    bool isColliding;
    
    void Start()
    {
        planet = FindObjectOfType<PlanetPhysics>();
        orig = planet.transform.position;
        foxBody = GetComponent<Rigidbody>();
        hoppingDir = new Vector3(0, 3, 1);
    }

    void Update()
    {
        normal = Vector3.Normalize(transform.position - planet.transform.position);

        Vector3 baseCross = Vector3.Cross(transform.forward, normal);
        Vector3 forward = Vector3.Cross(normal, baseCross);
        this.transform.rotation = Quaternion.LookRotation(forward, normal);

        if (isColliding)
        {
            transform.Rotate(0, 5, 0);
        }
        else {
            FollowKangaroo();
        }
    }

    void FollowKangaroo() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, kangarooMask);
        if (colliders.Length > 0) {
            for (int i = 0; i < colliders.Length; i++)
            {
                Vector3 baseCross = Vector3.Cross(colliders[i].transform.position, normal);
                Vector3 forward = Vector3.Cross(normal, baseCross);
                this.transform.rotation = Quaternion.LookRotation(forward, normal);
            }
        }
    }

    private void FixedUpdate()
    {
       
        if (GroundCheck())
        {
            onGround = true;
            Quaternion forceOrientation = Quaternion.LookRotation(transform.forward, normal);
            foxBody.AddForce(forceOrientation * hoppingDir * hoppingForce, ForceMode.Impulse);

        }
        else
        {
            onGround = false;
            foxBody.AddForce(-normal * g, ForceMode.Acceleration);
        }
    }

    bool GroundCheck() {
        RaycastHit hitinfo;
        Vector3 center = foxBody.worldCenterOfMass;
        if (Physics.Raycast(center, -normal, out hitinfo, groundCheckDis))
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Obstacle") {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            isColliding = false;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.3f);
        Gizmos.DrawSphere(transform.position,radius);
    }
}
