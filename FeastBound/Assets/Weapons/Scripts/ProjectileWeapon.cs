using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [Header("Projectile Stats")]

    // TOTAL AMMO: The total amount of ammo that a weapon has in its resevoir. 
    [SerializeField] private int totalAmmo;

    // CURRENT AMMO: The current amount of ammo in the chamber of the weapon. 
    [SerializeField] private int currentAmmo;

    // RELOAD SPEED: How long it takes for a weapon to fully reload.
    [SerializeField] private float reloadSpeed;

    /* RELOAD TYPE: "Full Reload" reloads the whole gun once it empties or when the player clicks the button.
                    "Single Reload" reloads the gun bullet by bullet and can be interrupted by the player. */
    private String reloadType;

    // BULLET SPREAD: How far at an angle each bullet fires. 
    [SerializeField] private float bulletSpread;

    // Setters
    public void SetCurrentAmmo(int amount) => this.currentAmmo = amount; 
    public void SetTotalAmmo(int amount) => this.totalAmmo = amount;
    public void SetReloadSpeed(float speed) => this.reloadSpeed = speed;
    public void SetBulletSpread(float spread) => this.bulletSpread = spread;

    // Getters
    public int GetCurrentAmmo() => this.currentAmmo;
    public int GetTotalAmmo() => this.totalAmmo;
    public float GetReloadSpeed() => this.reloadSpeed;
    public float GetBulletSpread() => this.bulletSpread;

    private void Reload()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Reloading");
        }
    }

    private void Update()
    {
        Fire();
        Swap();
    }
}
