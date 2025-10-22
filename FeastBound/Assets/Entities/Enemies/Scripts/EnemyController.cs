using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Enemy Stats
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemySpeed;
    [SerializeField] private string enemyType;
    [SerializeField] private float hitSpeed;

    // Sprite Components
    private GameObject sprite;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // NavMesh Components
    private Transform target;
    private NavMeshAgent agent;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private float moveDirectionX;
    private float moveDirectionY;

    // Hitbox timers
    private bool isHit;
    private float hitTimeCount;
    private float hitTime = .25f;

    // Attacking Variables
    private bool isAttacking;

    // Getters & Setters
    public float EnemyHealth { get => enemyHealth; set => enemyHealth = value; }
    public float EnemySpeed { get => enemySpeed; set => enemySpeed = value; }

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = enemySpeed;

        target = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player Projectile"))
        {
            Projectile projectileScript = collision.GetComponent<Projectile>();
            enemyHealth -= projectileScript.ProjectileDamage;
            hitTimeCount = hitTime;
        }
        if(collision.CompareTag("Player Slash"))
        {
            GameObject slashParent = collision.transform.parent.gameObject;
            MeleeWeapon weaponScript = slashParent.transform.parent.gameObject.GetComponent<MeleeWeapon>();
            enemyHealth -= weaponScript.Damage;
            hitTimeCount = hitTime;
        }
        if (collision.CompareTag("Player")  && enemyType == "Melee")
        {

        }
    }

    private float GetDirection(float directionx, float directiony)
    {
        directionx = Mathf.Sign(directionx);
        directiony = Mathf.Sign(directiony);

        // Define directional mappings
        var directionMap = new Dictionary<(float, float), float>
        {
        { (0, 1), 1 },   // North
        { (1, 1), 2 },   // North East
        { (1, 0), 3 },   // East
        { (1, -1), 4 },  // South East
        { (0, -1), 5 },  // South
        { (-1, -1), 6 }, // South West
        { (-1, 0), 7 },  // West
        { (-1, 1), 8 }   // North West
        };

        // Try to get the direction number based on the (x, y) pair
        if (directionMap.TryGetValue((directionx, directiony), out float direction))
        {
            return direction;
        }

        return 0; // Default if no match is found
    }

    void Update()
    {
        isHit = hitTimeCount > 0;

        lastPosition = currentPosition;
        currentPosition = gameObject.transform.position;

        moveDirectionX = currentPosition.x - lastPosition.x;
        moveDirectionY = currentPosition.y - lastPosition.y;

        if (!isAttacking && !isHit)
        {
            agent.speed = enemySpeed;
        }
        else
        {
            agent.speed = 0;
        }

        animator.SetFloat("DirectionValue", GetDirection(moveDirectionX, moveDirectionY));

        agent.SetDestination(target.position);

        hitTimeCount -= Time.deltaTime;
        if (isHit)
        {
            spriteRenderer.color = Color.red;
            agent.speed = hitSpeed;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(isHit);
    }
}
