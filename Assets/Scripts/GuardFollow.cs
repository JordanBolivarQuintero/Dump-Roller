using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardFollow : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    [SerializeField] float speed = 11;
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
