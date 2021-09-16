using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //för att patrullera
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attackera:(
    public float timeBetweenAttack;
    bool alreadyAttack;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerinAttackRange;

    private void Awake()
    {
        player = gameObject.GetComponent("FP player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
     //ska checka om spelaren syns och kan bli attackerad
     playerInSightRange = Physics.CheckSphere(//jobba här)
    }

    private void patroling()
    {

    }
    private void AttackPlayer()
    {

    }
    private void ChasePlayer()
    {

    }
}
