using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileWeapon : Weapon
{
    [Header("Projectile Weapon Stats")]

    // TOTAL AMMO: The total amount of ammo that a weapon has in its resevoir. 
    [SerializeField] private int totalAmmo;

    // CHAMBER TOTAL: The total amount of ammo a gun can hold in its chamber.
    [SerializeField] private int chamberTotal;

    // CURRENT AMMO: The current amount of ammo in the chamber of the weapon. 
    private int currentAmmo;

    // RELOAD SPEED: How long it takes for a weapon to fully reload.
    [SerializeField] private float reloadSpeed;

    /* RELOAD TYPE: "Full Reload" reloads the whole gun once it empties or when the player clicks the button.
                    "Single Reload" reloads the gun bullet by bullet and can be interrupted by the player. */
    [SerializeField] private String reloadType;

    // BULLET SPREAD: How far at an angle each bullet fires. 
    [SerializeField] private float bulletSpread;

    // the fire rate counters
    private float betweenFireTime = 1f;
    private float betweenFireTimeCounter = -1f;

    // the reload speed counters
    private float reloadTime = 1f;
    private float reloadTimeCounter;

    [Header("Projectile Prefab")]

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform bulletSpawnLocation;

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

    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        base.Awake();
        // Makes sure the current ammo in a gun is equal to the total it can carry when the game is loaded. 
        currentAmmo = chamberTotal;

        // sets all beam type weapons to a really high fire rate.
        if (GetWeaponType() == "Beam")
        {
            SetFireRate(100);
        }
    }

    private void Reload()
    {
        // amountRealoaded is the amount of ammo the gun needs to be filled, its calculated by finding the amount remaining in the chamber.
        // This number is then added to the chamber amount and subtracted from the total amount.
        int amountReloaded = Math.Abs(currentAmmo - chamberTotal);
        currentAmmo += amountReloaded;
        totalAmmo -= amountReloaded;
    }

    // returns true if the reloading timer is running, this stops players from firing and emulates reload speed.
    public bool IsReloading() 
    {
        return reloadTimeCounter > 0 && reloadTimeCounter < reloadTime;
    }

    private void BulletFire()
    {
        // When a bullet is fired, creates a clone object of the bullets prefab at a specified location and starts a timer.
        // While the timer is greater the zero the bullet will not fire, emulating fire speeds. 
        currentAmmo -= 1;
        GameObject projectileClone;
        projectileClone = Instantiate(projectile, bulletSpawnLocation.position, Quaternion.identity);
        Projectile projectileCloneScript = projectileClone.GetComponent<Projectile>();
        // this ensures the bullet always fires in the direction the gun is facing relative to its angle in GunRotation().
        projectileCloneScript.SetProjectileVelocity(GetMousePosX() - GetWeaponSprite().transform.position.x, GetMousePosY() - GetWeaponSprite().transform.position.y);
        betweenFireTimeCounter = betweenFireTime; // resets the timer after every bullet is fired. 
    }

    protected override void Update()
    {
        base.Update();

        if (isCollected() && !isEquipped())
        {
            gameObject.SetActive(false);
        }

        if (isEquipped()) {

            gameObject.SetActive(true);

            UpdateWeaponRotation();

            if (GetWeaponType() == "Bullet" && currentAmmo > 0)
            {
                // starts the fire rate counter if a gun is of the bullet type.
                betweenFireTimeCounter -= this.GetFireRate() * Time.deltaTime;

                // if the left mouse button is pressed and the gun is not reloading a bullet is fired initially.
                if (Input.GetMouseButtonDown(0) && !IsReloading())
                {
                    BulletFire();
                }
                // if the counter is finished, the gun isnt reloading and the left mouse button is held the gun fires at an automatic rate. 
                if (Input.GetMouseButton(0) && betweenFireTimeCounter <= 0 && !IsReloading())
                {
                    BulletFire();
                }
            }

            // This is a timer that starts once the reload key is pressed. *See the Reload() class for what it does*
            reloadTimeCounter -= reloadSpeed * Time.deltaTime;
            reloadTimeCounter = Mathf.Max(reloadTimeCounter, 0); // This keeps the value from dropping below zero.

            if (Input.GetKeyDown(KeyCode.R))
            {
                reloadTimeCounter = reloadTime;
                Reload();
            }

            Swap();
        }
    }
}
