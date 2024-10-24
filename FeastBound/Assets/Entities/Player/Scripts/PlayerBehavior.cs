using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    // STAT MODIFIER: The multiplier on different stats based on items picked up.
    [SerializeField] private StatModifier statModifier;

    // The value that determine the magnitude of the players speed.
    [SerializeField] private float moveSpeed;

    // Vector and rigidbody2D that is used to calculate the players movement.
    private Vector2 movement;
    private Rigidbody2D rb;

    [Header("Weapon Management")]
    // The weapons and items manager
    [SerializeField] private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;


    // If a player is colliding with an item or weapons pick up radius they can pick the object up by pressing the "F" key.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            GameObject weapon = collision.gameObject;
            if (Input.GetKey(KeyCode.F))
            {
                weapon.transform.parent = weaponsItemsObject.transform;
                Destroy(collision);
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponsItemsScript = weaponsItemsObject.GetComponent<WeaponsItemsManager>();
        Cursor.visible = false;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;
    }

}
