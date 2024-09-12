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
    private String rarity;

    // BULLET SIZE: How big each bullet, beam or the melee weapon itself is. 
    [SerializeField] private float Size;


    // Variable Setters
    public void SetDamage(float damage) => this.damage = damage;
    public void SetFireRate(float rate) => this.fireRate = rate;
    public void SetSize(float size) => this.Size = size;

    // Variable Getter
    public float GetDamage() => this.damage;
    public float GetFireRate() => this.fireRate;
    public float GetSize() => this.Size;

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
