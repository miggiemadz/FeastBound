using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [Header("Melee Weapon Stats")]
    // WEAPON DAMAGE: A range of values that will determine how much hp enemies lose when they get hit (4-6 hp per hit).
    [SerializeField] private float weaponDamage;
    // WEAPON SIZE: How big the melee weapon itself is. 
    [SerializeField] private float weaponSize;

    // Setters
    public void SetDamage(float damage) => this.weaponDamage = damage;
    public void SetSize(float size) => this.weaponSize = size;

    // Getters
    public float GetDamage() => this.weaponDamage;
    public float GetSize() => this.weaponSize;

    void Update()
    {
        Swap();
    }
}
