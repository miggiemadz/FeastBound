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

    [Header("Components")]
    private Vector3 mousePosition;

    [SerializeField] private GameObject weaponSprite;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private CircleCollider2D weaponCollectCollider;

    protected GameObject player;


    // Variable Setters
    public void SetFireRate(float rate) => this.fireRate = rate;

    // Variable Getter
    public float GetFireRate() => this.fireRate;
    public String GetWeaponType() => this.weaponType;
    public String GetWeaponRarity() => this.rarity;
    public float GetMousePosX() => this.mousePosition.x;
    public float GetMousePosY() => this.mousePosition.y;
    public GameObject GetWeaponSprite() => this.weaponSprite;

    protected virtual void Start()
    {
        
    }

    protected virtual void Awake()
    {
        player = GameObject.Find("TestPlayer");
    }

    protected float WeaponRotation() // returns the angle the gun should be at as it follows the cursor.
    {
        return Mathf.Atan2(mousePosition.y - player.transform.position.y, mousePosition.x - player.transform.position.x) * Mathf.Rad2Deg;
    }

    protected void Swap() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("WeaponManager").transform.GetChild(0).SetAsLastSibling();
            GameObject.Find("WeaponManager").transform.GetChild(0).gameObject.SetActive(true);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                gameObject.transform.parent = GameObject.Find("WeaponManager").transform;
                Destroy(weaponCollectCollider);
            }
        }
    }

    protected bool isEquipped()
    {
        Transform targetTransform;

        try
        {
            targetTransform = GameObject.Find("WeaponManager").transform.GetChild(0);
        }
        catch (System.Exception ex) when (ex is UnityException)
        {
            targetTransform = null;
        }

        return gameObject.transform == targetTransform;
    }

    protected bool isCollected()
    {
        return gameObject.transform.parent == GameObject.Find("WeaponManager").transform;
    }

    protected virtual void Update()
    {
        
    }
}
