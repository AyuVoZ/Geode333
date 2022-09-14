using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public delegate void HitCastle();
    public static event HitCastle onHitCastle;

    public Collider collide;
    public float Speed;
    GameObject[] waypoints;
    private int index;
    UnityEngine.AI.NavMeshAgent agent;
    private float timeBetweenHit = 1f;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position, out hit, 1.0f, 1);
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.Warp(hit.position);
        agent.SetDestination(waypoints[0].transform.position);
        index = 1;
    }
    void FixedUpdate()
    {
        if (index < waypoints.Length)
        {
            if (agent.hasPath || agent.pathPending)
                return;
            if (index < waypoints.Length)
            {
                agent.SetDestination(waypoints[index].transform.position);
                index++;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Time.fixedTime > startTime + timeBetweenHit && other.gameObject.name == "Castle")
        {
            onHitCastle();
            startTime = Time.fixedTime;
        }
    }
}
