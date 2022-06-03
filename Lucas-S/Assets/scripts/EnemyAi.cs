using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour

    //allt gjord av lucas 
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //f�r att patrullera
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

        if (!playerInSightRange && !playerinAttackRange) Patrulera();
        if (playerInSightRange && !playerinAttackRange) Jaga();
        if (playerInSightRange && playerinAttackRange) heheAttack();

    }

    private void Patrulera()
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
    private void heheAttack()
    {
       // agent.SetDestination(player.position); 
        
        if (!alreadyAttack)
        {

            //attack koden h�r


            alreadyAttack = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
    private void Jaga()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);

       
    }

    private void ResetAttack()
    {
        alreadyAttack = false;
    }

   //okej f�r att f�rklara detta p� det b�sta s�ttet m�jligt. S� skripptet �r halvt misslyckads men jag fick den viktigaste saken att funka. allts� det scriptet g�r �r att den
   //�r f�st vid ett objekt som d� blir v�ran fiende. den h�r fienden uppdateras d� och har 3 jobba att g�r (som du kan se i void update) patrulera, jaga, och attackera. 
   // patrullera s�nder ut en raycast som kommer checka om en spelare �r i n�rheten, om det �r det s� s�nder den ut true och om den inte �r det s�nder den ut det negativt
   // jaga aktiveras om patrullera g�r p� true, d� kommer den med hj�lp av navMeshAgent hitta och g� mot min spelare.
   //och sist men inte minst attack, men den blev typ helt fel. s� den spelar ingen st�rre roll. po�ngen var att den skulle stanna n�r spelaren kom i en viss rage och b�rja skjuta men vi kom aldrig till det stadiet
}


