using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [Header("Universal Weapon Stats")]
    // FIRE RATE: How fast each bullet is fired from the gun. 
    [SerializeField] private float fireRate;

    // RARITY: How good and rare it is to encounter a weapon. From least to greatest those are "Well Done", "Medium Well", "Medium", "Medium Rare" & "Rare".
    [SerializeField] private String rarity;

    /* WEAPON TYPE: "Bullet Type" is a weapon that fires seperate pellets at different rates.              
                    "Beam Type" is a weapon that fires a continuous beam that does damage over time.
                    "Melee Type" is a weapon that attacks at close range and usually does not fire a projectile. */
    [SerializeField] private String weaponType;

    // Variable Setters
    public void SetFireRate(float rate) => this.fireRate = rate;

    // Variable Getter
    public float GetFireRate() => this.fireRate;
    public String GetWeaponType() => this.weaponType;
    public String GetWeaponRarity() => this.rarity;

    protected void Swap() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Swapping");
        }
    }
}
