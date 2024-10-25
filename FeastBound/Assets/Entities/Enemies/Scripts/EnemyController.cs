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

    private float hitTimeCount;
    private float hitTime = .15f;

    // Setters
    public void SetEnemyHealth(float health) => this.enemyHealth = health;

    //Getters
    public float GetEnemyHealth() => this.enemyHealth;

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

    void Awake()
    {
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
