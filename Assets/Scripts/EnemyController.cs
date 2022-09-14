using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public float Speed;
    GameObject[] waypoints;
    private int index;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(waypoints[0].transform.position);
        index = 0;
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
}
