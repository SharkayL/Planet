using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject target;
    Vector3 relativePos;
    Vector3 normal;
    Quaternion rotation;
    public float d = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        relativePos = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
        normal = (transform.position - target.transform.position).normalized;
        //this.transform.position = (target.transform.position) + relativePos;
        this.transform.rotation = Quaternion.LookRotation(transform.forward, normal);
    }
}
