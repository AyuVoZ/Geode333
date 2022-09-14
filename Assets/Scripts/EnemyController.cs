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
    public int health;

    GameObject[] waypoints;
    private int index;
    UnityEngine.AI.NavMeshAgent agent;
    private float timeBetweenHit = 1f;
    private float startTime;
    private Animator animator;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            agent.SetDestination(transform.position);
            gameObject.tag = "Untagged";
            Invoke("DestroyBody", 3);
        }
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
    void DestroyBody()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Bullet(Clone)")
        {
            health--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Time.fixedTime > startTime + timeBetweenHit && other.gameObject.name == "Castle")
        {
            if (first)
                animator.SetBool("IsAttacking", true);
            onHitCastle();
            startTime = Time.fixedTime;
        }
    }
}
