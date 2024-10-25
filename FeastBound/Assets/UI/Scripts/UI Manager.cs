using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject AmmoUI;
    [SerializeField] private TextMeshProUGUI ammoText;

    private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;

    // Start is called before the first frame update
    void Start()
    {

        weaponsItemsObject = GameObject.Find("WeaponItemManager");
        weaponsItemsScript = weaponsItemsObject.GetComponent<WeaponsItemsManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
