using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [Header("Universal Stats")]
    // DAMAGE: A range of values that will determine how much hp enemies lose when they get hit (4-6 hp per hit).
    [SerializeField] private float damage;

    // FIRE RATE: How fast each bullet is fired from the gun. 
    [SerializeField] private float fireRate;

    // RARITY: How good and rare it is to encounter a weapon. From least to greatest those are "Well Done", "Medium Well", "Medium", "Medium Rare" & "Rare".
    [SerializeField] private String rarity;

    // BULLET SIZE: How big each bullet, beam or the melee weapon itself is. 
    [SerializeField] private float Size;

    /* WEAPON TYPE: "Bullet Type" is a weapon that fires seperate pellets at different rates.              
                    "Beam Type" is a weapon that fires a continuous beam that does damage over time.
                    "Melee Type" is a weapon that attacks at close range and usually does not fire a projectile. */
    [SerializeField] private String weaponType;

    // Variable Setters
    public void SetDamage(float damage) => this.damage = damage;
    public void SetFireRate(float rate) => this.fireRate = rate;
    public void SetSize(float size) => this.Size = size;

    // Variable Getter
    public float GetDamage() => this.damage;
    public float GetFireRate() => this.fireRate;
    public float GetSize() => this.Size;

    protected void Fire() 
    {
        if (weaponType == "Melee" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("HIYAH!");
        }
        if (weaponType == "Bullet" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pew Pew");
        }
        if (weaponType == "Beam" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("*Lazer Beam Sounds*");
        }
    }

    protected void Swap() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Swapping");
        }
    }
}
