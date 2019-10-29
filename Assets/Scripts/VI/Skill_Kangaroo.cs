using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Kangaroo : MonoBehaviour
{

    public float radius;
    public float Z;
    public LayerMask treeMask;

    bool isReturning;
    float currentTimer;
    public float returnTimer;

    void Update()
    {
        PunchTree();
    }
 
    void PunchTree() {
        Collider[] treeCollider = Physics.OverlapSphere(transform.position + transform.TransformDirection(new Vector3(0, 0, Z)), radius, treeMask);
        if (ControllerInput.GetButtonX() && !isReturning)
        {
            Vector3 forwardPos = transform.position + transform.TransformDirection(new Vector3(0, 0, Z));
            transform.position = forwardPos;
            for (int i = 0; i < treeCollider.Length; i++)
            {
                if (treeCollider.Length > 0)
                {
                    Destroy(treeCollider[i].gameObject);
                }
            }
            isReturning = true;
        }
        if (isReturning)
        {
            if (currentTimer < returnTimer)
            {
                currentTimer += Time.deltaTime;
            }
            else
            {
                Vector3 backWardPos = transform.position + transform.TransformDirection(new Vector3(0, 0, -Z));
                transform.position = backWardPos;
                currentTimer = 0;
                isReturning = false;
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,1,0.5f);
        Gizmos.DrawSphere(transform.position + transform.TransformDirection(new Vector3(0,0, Z)), radius);
    }
}
