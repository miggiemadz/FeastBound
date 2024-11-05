using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]

    [SerializeField] private float enemyHealth;

    // Sprite Components
    private GameObject sprite;
    private SpriteRenderer spriteRenderer;

    // NavMesh Components
    private Transform target;
    private NavMeshAgent agent;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private float moveDirectionX;
    private float moveDirectionY;

    // Hitbox timers
    private float hitTimeCount;
    private float hitTime = .15f;

    // Setters
    public void SetEnemyHealth(float health) => this.enemyHealth = health;

    //Getters
    public float GetEnemyHealth() => this.enemyHealth;

    void Awake()
    {
        sprite = transform.GetChild(0).gameObject;
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();

        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

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
    }

    void Update()
    {
        lastPosition = currentPosition;
        currentPosition = gameObject.transform.position;

        moveDirectionX = currentPosition.x - lastPosition.x;
        moveDirectionY = currentPosition.y - lastPosition.y;

        Debug.Log(Mathf.Round(moveDirectionX * 100f) + ", " + Mathf.Round(moveDirectionY * 100f));

        agent.SetDestination(target.position);

        hitTimeCount -= Time.deltaTime;
        if (hitTimeCount > 0)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(enemyHealth);
    }
}
