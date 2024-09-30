using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject AmmoUI;
    [SerializeField] private TextMeshProUGUI ammoText;

    [SerializeField] GameObject weapon;
    private ProjectileWeapon projectileWeaponScript;
    private MeleeWeapon meleeWeaponScript;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = AmmoUI.GetComponent<TextMeshProUGUI>();
        projectileWeaponScript = weapon.GetComponent<ProjectileWeapon>();
        meleeWeaponScript = weapon.GetComponent<MeleeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileWeaponScript != null)
        {
            if (projectileWeaponScript.IsReloading())
            {
                ammoText.SetText("Reloading...");
            }
            else
            {
                ammoText.SetText(projectileWeaponScript.GetCurrentAmmo().ToString() + "/" + projectileWeaponScript.GetTotalAmmo().ToString());
            }
        }
        if (meleeWeaponScript != null)
        {
            ammoText.SetText("\u221E" + " / " + "\u221E");
        }
        else
        {
            ammoText.SetText(" - / - ");
        }
    }
}
