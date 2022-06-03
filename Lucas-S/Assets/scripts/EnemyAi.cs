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

            //attack koden här


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

   //okej för att förklara detta på det bästa sättet möjligt. Så skripptet är halvt misslyckads men jag fick den viktigaste saken att funka. alltså det scriptet gör är att den
   //är fäst vid ett objekt som då blir våran fiende. den här fienden uppdateras då och har 3 jobba att gör (som du kan se i void update) patrulera, jaga, och attackera. 
   // patrullera sänder ut en raycast som kommer checka om en spelare är i närheten, om det är det så sänder den ut true och om den inte är det sänder den ut det negativt
   // jaga aktiveras om patrullera går på true, då kommer den med hjälp av navMeshAgent hitta och gå mot min spelare.
   //och sist men inte minst attack, men den blev typ helt fel. så den spelar ingen större roll. poängen var att den skulle stanna när spelaren kom i en viss rage och börja skjuta men vi kom aldrig till det stadiet
}


