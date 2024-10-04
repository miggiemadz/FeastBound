using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    // PROJECTILE DAMAGE: A range of values that will determine how much hp is lost when hit (4-6 hp per hit).
    [SerializeField] private float projectileDamage;

    // PROJECTILE SPEED: How fast the projectile travels after being fired.
    [SerializeField] private float projectileSpeed;

    // PROJECTILE SIZE: How big the projectile is. 
    [SerializeField] private float projectileSize;

    // PROJECTILE TYPE: Bullet or Beam.
    [SerializeField] private String projectileType;

    [Header("Bullet Components")]
    private Rigidbody2D rb2d;

    private Vector2 projectileMovement;

    private float projectileVelocityX;
    private float projectileVelocityY;

    // Setters
    public void SetProjectileDamage(float damage) => this.projectileDamage = damage;
    public void SetProjectileSpeed(float speed) => this.projectileSpeed = speed;
    public void SetProjectileSize(float size) => this.projectileSize = size;
    public void SetProjectileVelocity(float x, float y)
    {
        this.projectileVelocityX = x;
        this.projectileVelocityY = y;
    }

    //Getters
    public float GetProjectileDamage() => this.projectileDamage;
    public float GetProjectileSpeed() => this.projectileSpeed;
    public float GetProjectileSize() => this.projectileSize;
    public float GetProjectileVelocityX() => this.projectileVelocityX;
    public float GetProjectileVelocityY() => this.projectileVelocityY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") && gameObject.CompareTag("Player Projectile")) || // Player Bullet hits enemy
            (collision.CompareTag("Player") && gameObject.CompareTag("Enemey Projectile")) || // Enemy Bullet hits player
            collision.CompareTag("Boundaries")) // Bullet hits wall
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        // Bullets are fired in the direction the gun is facing and its speed is based on the projectileSpeed stat.
        rb2d.velocity = new Vector2(projectileVelocityX, projectileVelocityY).normalized * projectileSpeed; 

        // The size of the bullet changes dependent on the projectileSize stat
        gameObject.transform.localScale = new Vector3(projectileSize, projectileSize, 1);

    }
}
