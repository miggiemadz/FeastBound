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

    // PROJECTILE SOURCE: Whether the bullet is fired from the Player or Enemy.
    [SerializeField] private String projectileSource;

    [Header("Components")]
    private Rigidbody2D rb2d;

    private Vector2 projectileMovement;

    // Setters
    public void SetProjectileDamage(float damage) => this.projectileDamage = damage;
    public void SetProjectileSpeed(float speed) => this.projectileSpeed = speed;
    public void SetProjectileSize(float size) => this.projectileSize = size;

    //Getters
    public float GetProjectileSpeed() => this.projectileSpeed;
    public float GetProjectileSize() => this.projectileSize;
    public String GetProjectileSource() => this.projectileSource;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2d.velocity = new Vector2 (projectileSpeed, 0);
    }
}
