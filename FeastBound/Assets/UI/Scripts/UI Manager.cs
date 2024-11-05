using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Ammo UI Components
    private GameObject AmmoUI;
    private TextMeshProUGUI ammoText;
    private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;
    private Image weaponImage;

    // Health UI Components
    private PlayerBehavior playerBehaviorScript;
    private GameObject healthBar;
    private Slider healthSlider;
    private TextMeshProUGUI healthText;

    void Start()
    {
        healthBar = transform.GetChild(1).gameObject;
        playerBehaviorScript = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        healthSlider = healthBar.GetComponent<Slider>();
        healthText = healthBar.GetComponentInChildren<TextMeshProUGUI>();

        healthSlider.maxValue = playerBehaviorScript.MAX_PLAYER_HEALTH1;
        healthSlider.minValue = 0;

        AmmoUI = transform.GetChild(0).gameObject;
        ammoText = AmmoUI.GetComponent<TextMeshProUGUI>();
        weaponsItemsObject = GameObject.Find("WeaponItemManager");
        weaponsItemsScript = weaponsItemsObject.GetComponent<WeaponsItemsManager>();
        weaponImage = transform.GetChild(2).GetComponent<Image>();
    }

    void Update()
    {
        healthText.SetText(playerBehaviorScript.CurrentPlayerHealth.ToString() + " / " + playerBehaviorScript.MAX_PLAYER_HEALTH1);
        healthSlider.value = playerBehaviorScript.CurrentPlayerHealth;

        if (weaponsItemsScript.Weapons.Count != 0)
        {
            weaponImage.gameObject.SetActive(true);
            weaponImage.sprite = weaponsItemsScript.CurrentWeapon.GetComponentInChildren<SpriteRenderer>().sprite;
        }
        else
        {
            weaponImage.gameObject.SetActive(false);
        }

        if (weaponsItemsScript.NumWeapons <= 0)
        {
            ammoText.SetText(" - / - ");
        }

        else
        {
            if (weaponsItemsScript.CurrentWeapon.WeaponType == "Bullet")
            {
                ProjectileWeapon weaponScript = (ProjectileWeapon)weaponsItemsScript.CurrentWeapon;
                if (weaponScript.IsReloading())
                {
                    ammoText.SetText("Reloading...");
                }
                else
                {
                    ammoText.SetText(weaponScript.CurrentAmmo.ToString() + "/" + weaponScript.TotalAmmo.ToString());
                }
            }
            else
            {
                ammoText.SetText("\u221E" + " / " + "\u221E");

            }
        }

    }
}
