using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;

    [Header("Weapon Management")]
    [SerializeField] private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;

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
