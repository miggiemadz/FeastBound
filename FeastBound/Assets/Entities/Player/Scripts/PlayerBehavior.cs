using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement")]
    // STAT MODIFIER: The multiplier on different stats based on items picked up.
    [SerializeField] private StatModifier statModifier;

    // The value that determine the magnitude of the players speed.
    [SerializeField] private float moveSpeed;

    // Vector and rigidbody2D that is used to calculate the players movement.
    private Vector2 movement;
    private Rigidbody2D rb;

    [SerializeField] private float MAX_PLAYER_HEALTH;
    [SerializeField] private float currentPlayerHealth;

    [Header("Weapon Management")]
    // The weapons and items manager
    [SerializeField] private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;

    // Getters & Setters
    public float MoveSpeed { get => moveSpeed * statModifier.PlayerSpeedMod; set => moveSpeed = value; }
    public float CurrentPlayerHealth { get => currentPlayerHealth; set => currentPlayerHealth = value; }
    public float MAX_PLAYER_HEALTH1 { get => MAX_PLAYER_HEALTH; set => MAX_PLAYER_HEALTH = value; }

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

        if (collision.CompareTag("Item"))
        {
            GameObject item = collision.gameObject;
            if (Input.GetKey(KeyCode.F))
            {
                Item itemScript = item.GetComponent<Item>();
                itemScript.UpdateStatModifier();
                itemScript.UpdateResources();
                item.transform.parent = weaponsItemsObject.transform;
                item.SetActive(false);
                Destroy(collision);
            }
        }
    }

    private void Start()
    {
        statModifier = GameObject.Find("StatModifier").GetComponent<StatModifier>();
        currentPlayerHealth = MAX_PLAYER_HEALTH;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponsItemsScript = weaponsItemsObject.GetComponent<WeaponsItemsManager>();
        Cursor.visible = false;
    }

    public void UpdateHealth(float value)
    {
        CurrentPlayerHealth += value;
        if (CurrentPlayerHealth > MAX_PLAYER_HEALTH)
        {
            CurrentPlayerHealth = MAX_PLAYER_HEALTH;
        }
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * MoveSpeed;
    }

}
