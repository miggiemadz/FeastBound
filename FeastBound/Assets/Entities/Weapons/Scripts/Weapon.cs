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

    [SerializeField] protected bool isEquipped;
    [SerializeField] private bool isCollected;

    [Header("Components")]
    private Vector3 mousePosition;

    [SerializeField] private GameObject weaponSprite;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;

    protected GameObject player;

    // Variable Setters
    public void SetFireRate(float rate) => this.fireRate = rate;
    public void SetEquipped(bool value) => this.isEquipped = value;
    public void SetCollected(bool value) => this.isCollected = value;

    // Variable Getter
    public float GetFireRate() => this.fireRate;
    public String GetWeaponType() => this.weaponType;
    public String GetWeaponRarity() => this.rarity;
    public float GetMousePosX() => this.mousePosition.x;
    public float GetMousePosY() => this.mousePosition.y;
    public GameObject GetWeaponSprite() => this.weaponSprite;
    public bool GetEquipped() => this.isEquipped;
    public bool GetCollected() => isCollected;

    protected virtual void Start()
    {
        player = GameObject.Find("Player");
    }

    protected virtual void Awake()
    {

    }

    protected float WeaponRotation() // returns the angle the gun should be at as it follows the cursor.
    {
        return Mathf.Atan2(mousePosition.y - player.transform.position.y, mousePosition.x - player.transform.position.x) * Mathf.Rad2Deg;
    }

    protected void UpdateWeaponRotation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        weaponSprite.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y,
            WeaponRotation());
        
        if (WeaponRotation() > 90f || WeaponRotation() < -90f)
        {
            weaponSpriteRenderer.flipY = true;
            Transform leftHand = GameObject.Find("LeftHold").transform;
            gameObject.transform.position = new Vector3(leftHand.position.x, leftHand.position.y, -1);
        }
        else
        {
            weaponSpriteRenderer.flipY = false;
            Transform rightHand = GameObject.Find("RightHold").transform;
            gameObject.transform.position = new Vector3(rightHand.position.x, rightHand.position.y, -1);
        }
    }

    protected virtual void Update()
    {

    }
}
