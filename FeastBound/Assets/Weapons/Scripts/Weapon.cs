using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseWeaponScript
{
    // DAMAGE: A range of values that will determine how much hp enemies lose when they get hit (4-6 hp per hit).
    private float damage;

    // TOTAL AMMO: The total amount of ammo that a weapon has in its resevoir. 
    private int totalAmmo;

    // CURRENT AMMO: The current amount of ammo in the chamber of the weapon. 
    private int currentAmmo;

    // FIRE RATE: How fast each bullet is fired from the gun. 
    private float fireRate;

    // RELOAD SPEED: How long it takes for a weapon to fully reload.
    private float reloadSpeed;

    // RELOAD TYPE: "Full Reload" reloads the whole gun once it empties or when the player clicks the button.
    //              "Single Reload" reloads the gun bullet by bullet and can be interrupted by the player.
    private String reloadType;

    // WEAPON TYPE: "Bullet Type" is a weapon that fires seperate pellets at different rates.
    //              "Beam Type" is a weapon that fires a continuous beam that does damage over time.
    //              "Melee Type" is a weapon that does not usually fire anything but rather attacks up close.
    private String weaponType;

    // RARITY: How good and rare it is to encounter a weapon. From least to greatest those are "Well Done", "Medium Well", "Medium", "Medium Rare" & "Rare".
    private String rarity;

    // BULLET SIZE: How big each bullet, beam or the melee weapon itself is. 
    private float bulletSize;

    // BULLET SPREAD: How far at an angle each bullet fires. 
    private float bulletSpread;


    // Variable Setters
    public void SetDamage(float damage) => this.damage = damage;
    public void SetCurrentAmmo(int count) => this.currentAmmo = count;
    public void SetTotalAmmo(int count) => this.totalAmmo = count;
    public void SetFireRate(float rate) => this.fireRate = rate;
    public void SetReloadSpeed(float speed) => this.reloadSpeed = speed;
    public void SetBulletSize(float size) => this.bulletSize = size;
    public void SetBulletSpread(float  spread) => this.bulletSpread = spread;

    // Variable Getter
    public float GetDamage() => this.damage;
    public int GetCurrentAmmo() => this.currentAmmo;
    public int GetTotalAmmo() => this.totalAmmo;
    public float GetFireRate() => this.fireRate;
    public float GetReloadSpeed() => this.reloadSpeed;
    public float GetBulletSize() => this.bulletSize;
    public float GetBulletSpread() => this.bulletSpread;

    public BaseWeaponScript(float damage, int totalAmmo, int currentAmmo, float fireRate, float reloadSpeed, string reloadType, string weaponType, string rarity, float bulletSize, float bulletSpread)
    {
        this.damage = damage;
        this.totalAmmo = totalAmmo;
        this.currentAmmo = currentAmmo;
        this.fireRate = fireRate;
        this.reloadSpeed = reloadSpeed;
        this.reloadType = reloadType;
        this.weaponType = weaponType;
        this.rarity = rarity;
        this.bulletSize = bulletSize;
        this.bulletSpread = bulletSpread;
    }

    private void Fire() 
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Pew Pew");
        }
    }

    private void Reload() 
    {
        if (Input.GetKey(KeyCode.R)) {
            Debug.Log("Reloading");
        }
    }

    private void Swap() 
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Swapping");
        }
    }
}
