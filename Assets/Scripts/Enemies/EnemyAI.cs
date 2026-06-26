using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange = 12f;
    public float attackRange = 2f;
    public float attackCooldown = 1.2f;
    public float attackDamage = 10f;

    [Header("Patrol")]
    public Transform[] waypoints;
    private int wpIndex = 0;

    private NavMeshAgent agent;
    private Transform player;
    private float lastAtk = -999f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        NextWP();
    }

    void NextWP()
    {
        if (waypoints.Length == 0) return;
        agent.destination = waypoints[wpIndex].position;
        wpIndex = (wpIndex + 1) % waypoints.Length;
    }

    void Update()
    {
        if (!player) return;
        float d = Vector3.Distance(transform.position, player.position);

        if (d <= attackRange)
        {
            agent.destination = transform.position;
            transform.LookAt(player);
            if (Time.time >= lastAtk + attackCooldown)
            {
                lastAtk = Time.time;
                player.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
                Debug.Log("Enemy attacked player!");
            }
        }
        else if (d <= detectionRange)
            agent.destination = player.position;
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
            NextWP();
    }
}
