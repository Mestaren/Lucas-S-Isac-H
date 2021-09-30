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
        player = GameObject.Find("FPplayer").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //ska checka om spelaren syns och kan bli attackerad
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerinAttackRange) patroling();
        if (playerInSightRange && !playerinAttackRange) ChasePlayer();
        if (playerInSightRange && playerinAttackRange) AttackPlayer();

    }

    private void patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distansToWalkPoint = transform.position - walkPoint;

        if (distansToWalkPoint.magnitude > 1f)
            walkPointSet = false;
    }
     private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }
    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);

        if (!alreadyAttack)
        {

            //attack koden här


            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }
}
