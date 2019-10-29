//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////[discarded]
////recalculation needed;

//public class BadPeople : EnemyBehavior
//{
//    public Transform eyePos; //higer than the body
//    // Start is called before the first frame update
//    protected new void Start()
//    {
//        base.Start();
//    }

//    // Update is called once per frame
//    protected new void Update()
//    {
//        if (canSee())
//        {
//            if (!decisionMade)
//            {
//                chasingMode = ChoseChasingmode();
//                decisionMade = true;
//            }
//            currentState = enemyStates.chasing;
//        }
//        else { decisionMade = false; }

//        if (ObstacleCheck(transform.forward))
//        {
//            if (currentState != enemyStates.chasing && Vector3.Distance(this.transform.position, targetPos) < 0.2)
//            {
//                Navigation();
//            }
//        }
//    }
//    public override bool canSee()
//    {
//        if (Vector3.Distance(currentTargetBody.position, this.transform.position) <= 0.3)
//        {
//            Vector3 v = currentTargetBody.position - this.transform.position;
//            if (Vector3.Angle(this.transform.forward, v.normalized) <= visibleAngle)
//            {
//                if (!ObstacleCheck(v.normalized))
//                {
//                    return true;
//                }
//            }
//        }
//        return false;
//    }

//    bool ObstacleCheck(Vector3 lookDirection)
//    {
//        RaycastHit hit;
//        if (Physics.Raycast(eyePos.position, lookDirection, out hit, visibleDistance))
//        {
//            if (hit.rigidbody != currentTargetBody)
//            {
//                return true;
//            }
//        }
//        return false;
//    }
//}
