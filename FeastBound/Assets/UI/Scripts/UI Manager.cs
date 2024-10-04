using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject AmmoUI;
    [SerializeField] private TextMeshProUGUI ammoText;

    GameObject weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.Find("WeaponManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponManager.transform.childCount == 0)
        {
            ammoText.SetText(" - / - ");
        }

        else
        {
            ProjectileWeapon weaponScript = weaponManager.transform.GetChild(0).GetComponent<ProjectileWeapon>();
            if (weaponScript != null)
            {
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
