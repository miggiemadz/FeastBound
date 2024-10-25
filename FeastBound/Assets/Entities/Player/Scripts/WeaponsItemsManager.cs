using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsItemsManager : MonoBehaviour
{
    // Lists that hold both the items and weapons that the player has picked up in a run.
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private List<Item> items;

    // Returns the size of the weapons List to determine how many weapons the player is holding. 
    public int NumWeapons { get { return weapons.Count; } }

    // Same as the weapons but for items.
    public int NumItems { get { return items.Count; } }

    // Returns the first object in the weapons class to determine what weapon the player currently has.
    public Weapon CurrentWeapon {  get { return weapons[0]; } }

    private int frames;

    void Start()
    {
        
    }

    private void SwapWeapons()
    {
        /** If the "E" key is pressed the player then switches weapons.
          * This is done by taking the first value in the last, removing and pushing it to the back of the list. **/
        if (Input.GetKeyDown(KeyCode.E))
        {
            Weapon currentWeapon = CurrentWeapon;
            weapons.RemoveAt(0);
            weapons.Add(currentWeapon);
        }
    }

    void Update()
    {
        frames++; // Keeps count of the frames

        if (frames % 30 == 0) // Runs the respective methods once every 30 frames
        {
            if (weapons.Count > 0)
            {
                // Runs through the weapons List and consistently sets the first weapon to the equipped and active object.
                foreach (Weapon weapon in weapons)
                {
                    if (weapon != CurrentWeapon)
                    {
                        weapon.IsEquipped = false;
                        weapon.gameObject.SetActive(false);
                    }
                    else
                    {
                        weapon.IsEquipped = true; ;
                        weapon.gameObject.SetActive(true);
                    }
                }
            }

            /** Runs through all the children of the weapons&item manager and checks if they have been collected before or not.
             * if not then add it to the weapons & items list respectively. **/
            foreach (Transform child in gameObject.transform)
            {
                Weapon weapon = child.GetComponent<Weapon>();
                Item item = child.GetComponent<Item>();

                if (weapon != null && !weapon.IsCollected)
                {
                    weapons.Add(weapon);
                    weapon.IsCollected = true;
                }

                if (item  != null && !item.IsCollected)
                {
                    items.Add(item);
                    item.IsCollected = true;
                }
            }
        }
        SwapWeapons();
    }
}
