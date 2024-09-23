using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector2 movement;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    private void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;
    }

}
