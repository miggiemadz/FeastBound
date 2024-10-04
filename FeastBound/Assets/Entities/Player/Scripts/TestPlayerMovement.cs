using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector2 movement;

    private Rigidbody2D rb;

    [SerializeField] private GameObject weaponManager;

    private bool hasWeapon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!hasWeapon && weaponManager.transform.childCount != 0)
        {            
            hasWeapon = true;
        }

        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;
    }

}
