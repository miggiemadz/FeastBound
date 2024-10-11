using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsItemsManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private List<Item> items;

    public int GetNumWeapons() => weapons.Count;
    public int GetNumItems() => items.Count;

    public Weapon GetCurrentWeapon() => weapons[0];

    void Start()
    {
        
    }

    private void SwapWeapons()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Weapon currentWeapon = weapons[0];
            weapons.RemoveAt(0);
            weapons.Add(currentWeapon);
        }
    }

    void Update()
    {
        if (weapons.Count > 0)
        {
            foreach (Weapon weapon in weapons)
            {
                if (weapon != GetCurrentWeapon())
                {
                    weapon.SetEquipped(false);
                    weapon.gameObject.SetActive(false);
                }
                else
                {
                    weapon.SetEquipped(true);
                    weapon.gameObject.SetActive(true);
                }
            }
        }

        foreach (Transform child in gameObject.transform)
        {
            Weapon weapon = child.GetComponent<Weapon>();  
            if (weapon != null && !weapon.GetCollected())  
            {
                weapons.Add(weapon); 
                weapon.SetCollected(true);
            }
        }

        SwapWeapons();
    }
}
