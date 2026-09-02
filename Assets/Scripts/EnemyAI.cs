using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    /*How to use:
     1. Attach 
     */

    public Transform player;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            agent.SetDestination(player.position);
    }
}
