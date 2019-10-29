using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBirds : EnemyBehavior
{
    Turtle targetTurtle;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        patrollingSpeed = 3;
        chasingSpeed = 6;
        height = Vector3.Distance(this.transform.position, planet.transform.position) - planet.radius;
        targetPos = CirclePositioning(transform);
        patrollingOffset = 5;
        chasingOffset = 1;
        visibleAngle = 30;
        targetTurtle = FindObjectOfType<Turtle>();
        currentTargetBody = targetTurtle.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Debug.DrawLine(transform.position, targetPos);
    }

    public override bool canSee()
    {
        //if (Vector3.Angle(-normal, (currentTargetBody.transform.position - this.transform.position)) <= visibleAngle)
        //{

            RaycastHit hit;
            if (Physics.Raycast(transform.position, (currentTargetBody.transform.position - transform.position), out hit, 2*height))
            {
                Debug.DrawLine(transform.position, hit.point);
                if (hit.rigidbody == currentTargetBody)
                {
                    
                        //Debug.DrawLine(transform.position, hit.point);

                        return true;
                    
                }
            }
        //}
        return false;
    }
}
