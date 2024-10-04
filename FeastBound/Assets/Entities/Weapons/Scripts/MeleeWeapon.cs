using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [Header("Melee Weapon Stats")]
    // WEAPON DAMAGE: A range of values that will determine how much hp enemies lose when they get hit (4-6 hp per hit).
    [SerializeField] private float weaponDamage;
    // WEAPON SIZE: How big the melee weapon itself is. 
    [SerializeField] private float weaponSize;

    [Header("Melee Weapon Components")]

    [SerializeField] private GameObject weaponSlashFX;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private GameObject weaponSlashHitBox;
    private PolygonCollider2D weaponSlashHitBoxCollider;

    private float swingTimer = 0.25f;
    private float swingTimerCount;

    // Setters
    public void SetDamage(float damage) => this.weaponDamage = damage;
    public void SetSize(float size) => this.weaponSize = size;

    // Getters
    public float GetDamage() => this.weaponDamage;
    public float GetSize() => this.weaponSize;

    private void Awake()
    {
        weaponSlashFX.SetActive(false);
        weaponSlashHitBoxCollider = weaponSlashHitBox.GetComponent<PolygonCollider2D>();
        weaponSlashHitBox.SetActive(false);
    }

    private void Swing()
    {
        if (Input.GetMouseButtonDown(0) && swingTimerCount <= 0){ 
            swingTimerCount = swingTimer;
        }
    }

    private void Update()
    {
        if (isCollected() && !isEquipped())
        {
            gameObject.SetActive(false);
        }

        if (isEquipped())
        {
            gameObject.SetActive(true);
            swingTimerCount -= Time.deltaTime;
            swingTimerCount = Mathf.Max(swingTimerCount, 0);

            if (swingTimerCount > 0)
            {
                weaponSlashFX.SetActive(true);
                weaponSlashHitBox.SetActive(true);
            }
            else
            {
                weaponSlashFX.SetActive(false);
                weaponSlashHitBox.SetActive(false);
            }

            weaponSlashFX.transform.position = new Vector3(weaponTip.position.x, weaponTip.position.y, -1);
            weaponSlashFX.transform.rotation = Quaternion.Euler(0, 0, WeaponRotation());

            UpdateWeaponRotation();

            Swing();

            Swap();
        }
    }
}
