using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour
{
    
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,1,0.3f);
        Gizmos.DrawSphere(transform.position,GetComponent<SphereCollider>().radius);
    }
}
