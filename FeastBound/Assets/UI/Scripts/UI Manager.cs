using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject AmmoUI;
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] private GameObject weaponsItemsObject;
    private WeaponsItemsManager weaponsItemsScript;

    // Start is called before the first frame update
    void Start()
    {
        weaponsItemsScript = weaponsItemsObject.GetComponent<WeaponsItemsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsItemsScript.GetNumWeapons() <= 0)
        {
            ammoText.SetText(" - / - ");
        }

        else
        {
            if (weaponsItemsScript.GetCurrentWeapon().GetWeaponType() == "Bullet")
            {
                ProjectileWeapon weaponScript = (ProjectileWeapon)weaponsItemsScript.GetCurrentWeapon();
                if (weaponScript.IsReloading())
                {
                    ammoText.SetText("Reloading...");
                }
                else
                {
                    ammoText.SetText(weaponScript.GetCurrentAmmo().ToString() + "/" + weaponScript.GetTotalAmmo().ToString());
                }
            }
            else
            {
                ammoText.SetText("\u221E" + " / " + "\u221E");

            }
        }

    }
}
