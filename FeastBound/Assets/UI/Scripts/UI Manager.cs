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
    [SerializeField] private ProjectileWeapon weaponScript;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = AmmoUI.GetComponent<TextMeshProUGUI>();
        weaponScript = weapon.GetComponent<ProjectileWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        if (weaponScript.IsReloading())
        {
            ammoText.SetText("Realoading...");
        }
        else
        {
            ammoText.SetText(weaponScript.GetCurrentAmmo().ToString() + "/" + weaponScript.GetTotalAmmo().ToString());
        }
    }
}
