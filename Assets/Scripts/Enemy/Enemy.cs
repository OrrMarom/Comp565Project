using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject wreckedVersion;

    bool inAttack;

    // Set time between attacks to length of jump animation
    private float timeBetweenAttacks = 1.333f;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private float health = 100;
    private float stuckCheckTime;
    private Vector3 stuckCheckPosition;

    Animator anim;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // Let attack continue
        if (!inAttack)
        {
            if (!playerInSightRange && !playerInAttackRange)
                Patrolling();
            else if (playerInSightRange && !playerInAttackRange)
                ChasePlayer();
            else if (playerInAttackRange)
                AttackPlayer();
        }


    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.isStopped = false;
        anim.SetInteger("Walk", 1);

        if (!walkPointSet)
        {
            SearchWalkPoint();
            // Update stuck values
            stuckCheckTime = Time.time;
            stuckCheckPosition = transform.position;
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            // Check if we are stuck every 2 seconds
            if (Time.time > stuckCheckTime + 2)
            {
                float distance = Vector3.Distance(stuckCheckPosition, transform.position);

                // Update stuck values
                stuckCheckTime = Time.time;
                stuckCheckPosition = transform.position;
                
                // Stuck, set a new walkpoint
                if (distance < 0.5f)
                {
                    Debug.Log(gameObject.name + " stuck, generating new walkpoint");
                    walkPointSet = false;
                }
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        while (true)
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            // Find random walk point
            Vector3 randomWalkPoint = Random.insideUnitSphere * walkPointRange;
            randomWalkPoint += transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(randomWalkPoint, out hit, walkPointRange, 1);
            Vector3 randomPosition = hit.position;

            walkPoint = randomPosition;

            // Ensure this puts us on ground
            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            {
                walkPointSet = true;
                break;
            }

            //
            // Raycast in each direction to find a place to traverse in maze
            /*
            RaycastHit hitInfo;
            bool ray = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, 1);

            if (ray)
            {
                Debug.Log("ray here, continuing")
            }
            else
            {
                Debug.Log("no ray, break")
            }
            

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            {
                walkPointSet = true;
                break;
            }
            */
        }

    }

    private void ChasePlayer()
    {
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.isStopped = false;
        anim.SetInteger("Walk", 1);

        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Don't move while attacking
        anim.SetInteger("Walk", 0);
        //agent.SetDestination(new Vector3(player.position.x, player.position.y + 1, player.position.z));

        transform.LookAt(player);

        if (!inAttack)
        {
            // Do attack
            inAttack = true;
            agent.updatePosition = false;
            agent.updateRotation = false;
            agent.isStopped = true;
            //rb.isKinematic = false;
            //rb.useGravity = true;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(0, 300, 0);
            anim.SetTrigger("jump");

            // Damage code for player goes here


            // Reset attack
            playerInAttackRange  = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        inAttack = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), .5f);
        }
    }

    public void DestroyEnemy()
    {
        // Enemy should be hidden and without collision
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<Collider>().enabled = false;

        // Take off enemy tag so it is not destroyed twice
        this.gameObject.tag = "Untagged";

        GameObject wrecked = Instantiate(wreckedVersion, transform.position, transform.rotation);
        //StartCoroutine(fadeAndDestroy(wrecked));
        foreach (Transform child in wrecked.transform)
        {
            StartCoroutine(fadeAndDestroy(child.gameObject));
            Debug.Log(child.gameObject.name);
        }
        MazeLevel.Instance.addToScore(250);
    }

    private IEnumerator fadeAndDestroy(GameObject enemy)
    {
        float time_until_fade = Random.Range(1f, 2f);
        float fade_until_destroy = 2f;
        float alpha = 1.0f;

        // Delay fade for some time
        yield return new WaitForSeconds(time_until_fade);

        // Fade cube out and destroy
        Material subcube_mat = enemy.GetComponent<Renderer>().material;
        while (alpha > 0.0f)
        {
            alpha = alpha - (fade_until_destroy * Time.deltaTime);
            subcube_mat.color = new Color(subcube_mat.color.r, subcube_mat.color.g, subcube_mat.color.b, alpha);
            yield return new WaitForEndOfFrame();
        }
        Destroy(enemy);

        yield return null;
    }
}
