using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Dog : MonoBehaviour
{
	public Transform destination;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(new Vector3(destination.position.x,transform.position.y,destination.position.z));
    }
}
