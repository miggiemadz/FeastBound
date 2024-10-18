using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponNameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weaponText;

    [SerializeField] private Transform weaponTextPosition;

    [SerializeField] private Weapon weaponScript;

    private void Update()
    {
        weaponText.transform.position = weaponTextPosition.position;

        if (weaponScript.GetCollected())
        {
            Destroy(weaponText);
        }
    }
}
