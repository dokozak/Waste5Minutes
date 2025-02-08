using UnityEngine;
using UnityEngine.AI;

public class WalkWhileThePlayerWalk : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

            player = GameObject.FindGameObjectWithTag("Player").transform;


        lastPlayerPosition = player.position;
    }

    void Update()
    {
        if (IsPlayerStill())
        {
            agent.SetDestination(transform.position);
            
        }
        else
        {
            agent.SetDestination(player.position);
        }

        lastPlayerPosition = player.position;
    }

    bool IsPlayerStill()
    {
        return Vector3.Distance(player.position, lastPlayerPosition) < 0.001f;
    }
}
