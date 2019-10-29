using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//updating calculation needed

public enum enemyStates {
    chasing,
    patrolling,
    distracted,
    goingback,
    idle
}
public enum chasingModes {
    circleChasing,
    targetChasing
}
public class EnemyBehavior : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;
    public Rigidbody currentTargetBody;
    
    public Rigidbody enemyBody;
    float timer = 0;
    public enemyStates currentState;
    public chasingModes chasingMode;
    public bool decisionMade = false;
    public float visibleAngle;
    //public float visibleDistance = 0.5f;
    public Vector3 normal;
    public PlanetPhysics planet;
    public float patrollingSpeed;
    public float chasingSpeed;

    public float speed = 1;
    public bool arrived = false;
    public float patrollingOffset;
    public float chasingOffset;
    public float height;
    bool timing;
    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        planet = FindObjectOfType<PlanetPhysics>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

        switch (currentState) {
            case enemyStates.patrolling:
                Patrolling();
                break;
            case enemyStates.chasing:
                Chasing();
                break;
            case enemyStates.distracted:
                Distracted();
                break;
            case enemyStates.idle:
                Idle();
                break;
            case enemyStates.goingback:
                GoingBack();
                break;
            default:
                Patrolling();
                break;
        }

        if (Vector3.Distance(targetPos, this.transform.position) <= 0.3 && currentState != enemyStates.goingback)
        {
            arrived = true;
            if (currentState == enemyStates.chasing)
            {
                currentState = enemyStates.goingback;
                arrived = false;
                timing = true;
            }

        }

        normal = (this.transform.position - planet.transform.position).normalized;

        if (canSee() && currentState == enemyStates.patrolling && timing == false)
        {
            
            //if (!decisionMade)
            //{
            //    chasingMode = ChoseChasingmode();
            //    decisionMade = true;
            //}
            currentState = enemyStates.chasing;
        }
        if (timing) {
            timer += Time.deltaTime;
            if (timer >= 10) {
                timer = 0;
                timing = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (currentState == enemyStates.patrolling)
        {
            MoveTo(targetPos, patrollingSpeed);
        }
        else if (currentState == enemyStates.chasing || currentState == enemyStates.goingback) {
            MoveTo(targetPos, chasingSpeed);
        }
    }



    void Patrolling() {
        if (arrived)
        {
            targetPos = CirclePositioning(transform);
            arrived = false;
        }
    }

    void Chasing() {
        //targetPos = TargetPosition(chasingModes.targetChasing);
        targetPos = currentTargetBody.transform.position;
    }

    void Distracted() { }
    void Idle() {
        timer += Time.deltaTime;
        if (timer >= 3) {
            timer = 0;
            currentState = enemyStates.patrolling;
            targetPos = TargetPosition(chasingModes.targetChasing);
        }
    }
    void GoingBack() {
        targetPos = normal * (planet.radius + height);

        if((targetPos - transform.position).magnitude < 0.3)
        {
            currentState = enemyStates.patrolling;
        }
    }

    void MoveTo(Vector3 targetPos, float speed) {
        Vector3 p = transform.position + transform.forward * speed * Time.deltaTime;
        if (currentState == enemyStates.chasing || currentState == enemyStates.goingback)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.Normalize(targetPos - transform.position), normal);
            //p = (transform.position + (targetPos - transform.position).normalized * speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.Normalize(targetPos - transform.position), normal);
            transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;
        }
        else
        {
            Vector3 forwardPoint = (transform.forward + transform.position - planet.transform.position).normalized * (planet.radius + height) + planet.transform.position ;
            transform.rotation = Quaternion.LookRotation(forwardPoint - transform.position, normal);
            transform.position = (p - planet.transform.position).normalized * (planet.radius + height);
        }
        
    }

    //public chasingModes ChoseChasingmode() {
    //    int index = Mathf.RoundToInt(Random.Range(0, 1));
    //    if (index == 0)
    //    {
    //        return chasingModes.targetChasing;
    //    }
    //    else return chasingModes.circleChasing;
    //}

    public Vector3 CirclePositioning(Transform center)
    {
        Vector3 dirTo = Vector3.Normalize(center.position - this.transform.position);
        Vector3 dir = Vector3.Normalize(Vector3.Cross(dirTo, center.up));
        targetPos = center.position + (dir - dirTo) / 2 * patrollingOffset;
        return targetPos;
    }
    public Vector3 PredictedPositioning(Transform target) {
        targetPos = target.position + target.forward * 1;
        return targetPos;
    }

    public Vector3 TargetPosition(chasingModes chasingMode) {
        if (chasingMode == chasingModes.circleChasing) {
            return CirclePositioning(currentTargetBody.transform);
        }
        else return PredictedPositioning(currentTargetBody.transform);
    }

    public void Navigation() {
        //avoid obstacle;
    }

    public virtual bool canSee() {
        return false;
    }
}
