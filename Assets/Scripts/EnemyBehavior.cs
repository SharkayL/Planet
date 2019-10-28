using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyStates {
    chasing,
    patrolling,
    distracted,
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
    public Transform eyePos; //higer than the body
    Rigidbody enemyBody;
    float timer = 0;
    public enemyStates currentState;
    public chasingModes chasingMode;
    bool decisionMade = false;
    float visibleAngle = 80;
    float visibleDistance = 0.5f;
    Vector3 normal;
    PlanetPhysics planet;

    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        planet = FindObjectOfType<PlanetPhysics>();
    }

    // Update is called once per frame
    void Update()
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
            default:
                Patrolling();
                break;
        }
        normal = (this.transform.position - planet.transform.position).normalized;
        if (canSee())
        {
            if (!decisionMade)
            {
                chasingMode = ChoseChasingmode();
                decisionMade = true;
            }
            currentState = enemyStates.chasing;
        }
        else { decisionMade = false; }

        if (ObstacleCheck(transform.forward)) {
            if (currentState != enemyStates.chasing && Vector3.Distance(this.transform.position, targetPos) < 0.2)
            {
                Navigation();
            }
        }
    }
    private void FixedUpdate()
    {
        if (currentState == enemyStates.patrolling || currentState == enemyStates.chasing)
        {
            MoveTo(targetPos);
        }
    }

    bool canSee(){       
        if (Vector3.Distance(currentTargetBody.position, this.transform.position) <= 0.3) {
            Vector3 v = currentTargetBody.position - this.transform.position;
            if (Vector3.Angle(this.transform.forward, v.normalized) <= visibleAngle) {
                if (!ObstacleCheck(v.normalized)) {
                    return true;
                }
            }
        }
        return false;
    }

    bool ObstacleCheck(Vector3 lookDirection) {
        RaycastHit hit;
        if (Physics.Raycast(eyePos.position, lookDirection, out hit, visibleDistance)) {
            if (hit.rigidbody != currentTargetBody) {
                return true;
            }
        }
        return false;
    }

    void Patrolling() {
        if (Vector3.Distance(transform.position, targetPos) <= 0.1 || targetPos == Vector3.zero)
        {
            targetPos = TargetPosition(chasingModes.targetChasing);
        }
    }

    void Chasing() {
        targetPos = targetPos = TargetPosition(chasingMode);
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

    void MoveTo(Vector3 targetPos) {
        transform.up = normal;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(targetPos.x, transform.position.y, targetPos.z), normal);
        transform.rotation = rotation;
        Vector3 p = transform.position + transform.forward * Time.deltaTime * speed;
        float d = Vector3.Distance(p, Vector3.zero);
        transform.position = p * (planet.radius / d);
    }

    chasingModes ChoseChasingmode() {
        int index = Mathf.RoundToInt(Random.Range(0, 1));
        if (index == 0)
        {
            return chasingModes.targetChasing;
        }
        else return chasingModes.circleChasing;
    }

    Vector3 TargetPosition(chasingModes chasingMode) {
        if (chasingMode == chasingModes.circleChasing) {
            return currentTargetBody.transform.position;
        }
        else return targetPos;
    }

    void Navigation() {
        //avoid obstacle;
    }


}
