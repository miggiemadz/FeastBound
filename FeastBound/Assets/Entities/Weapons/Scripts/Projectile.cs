using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    // STAT MODIFIER: The multiplier on different stats based on items picked up.
    [SerializeField] private StatModifier statModifier;

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

    private Vector2 projectileVelocity;

    // Getters & Setters
    public float ProjectileDamage { get => projectileDamage * statModifier.ProjectileDamageMod; set => projectileDamage = value; }
    public float ProjectileSpeed { get => projectileSpeed * statModifier.ProjectileSpeedMod; set => projectileSpeed = value; }
    public float ProjectileSize { get => projectileSize * statModifier.ProjectileSizeMod; set => projectileSize = value; }
    public Vector2 ProjectileVelocity { get => projectileVelocity; set => projectileVelocity = value; }
    public string ProjectileType { get => projectileType; set => projectileType = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") && gameObject.CompareTag("Player Projectile")) || // Player Bullet hits enemy
            (collision.CompareTag("Player") && gameObject.CompareTag("Enemy Projectile")) || // Enemy Bullet hits player
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
        statModifier = GameObject.Find("StatModifier").GetComponent<StatModifier>();
    }

    private void FixedUpdate()
    {
        // Bullets are fired in the direction the gun is facing and its speed is based on the projectileSpeed stat.
        rb2d.velocity = projectileVelocity.normalized * projectileSpeed; 

        // The size of the bullet changes dependent on the projectileSize stat
        gameObject.transform.localScale = new Vector3(projectileSize, projectileSize, 1);

    }
}
