using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]

    [SerializeField] private float enemyHealth;

    [Header("Enemy Components")]

    [SerializeField] private GameObject sprite;
    private SpriteRenderer spriteRenderer;

    // Setters
    public void SetEnemyHealth(float health) => this.enemyHealth = health;

    //Getters
    public float GetEnemyHealth() => this.enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player Projectile"))
        {
            Projectile projectileScript = collision.GetComponent<Projectile>();
            enemyHealth -= projectileScript.GetProjectileDamage();
        }
    }

    void Awake()
    {
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
