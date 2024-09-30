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

    [Header("Sprite Components")]
    [SerializeField] protected GameObject reticle;

    private Vector3 mousePosition;

    [SerializeField] private GameObject weaponSprite;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;

    // Variable Setters
    public void SetFireRate(float rate) => this.fireRate = rate;
    public void SetReticleXY(float x, float y)
    {
        reticle.transform.position = new Vector3(x, y, 0);
    }

    // Variable Getter
    public float GetFireRate() => this.fireRate;
    public String GetWeaponType() => this.weaponType;
    public String GetWeaponRarity() => this.rarity;
    public float GetMousePosX() => this.mousePosition.x;
    public float GetMousePosY() => this.mousePosition.y;
    public GameObject GetWeaponSprite() => this.weaponSprite;

    protected float WeaponRotation() // returns the angle the gun should be at as it follows the cursor.
    {
        return Mathf.Atan2(mousePosition.y - weaponSprite.transform.position.y, mousePosition.x - weaponSprite.transform.position.x) * Mathf.Rad2Deg;
    }

    protected void Swap() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Swapping");
        }
    }

    protected void UpdateWeaponRotation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        weaponSprite.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y,
            WeaponRotation());
        
        if (WeaponRotation() > 90f || WeaponRotation() < -90f)
        {
            weaponSpriteRenderer.flipY = true;
        }
        else
        {
            weaponSpriteRenderer.flipY = false;
        }

        SetReticleXY(mousePosition.x, mousePosition.y);
    }

}
