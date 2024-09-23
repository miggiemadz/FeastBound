using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]

    [SerializeField] private float enemyHealth;


    // Setters
    public void SetEnemyHealth(float health) => this.enemyHealth = health;

    //Getters
    public float GetEnemyHealth() => this.enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player Projectile"))
        {

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
