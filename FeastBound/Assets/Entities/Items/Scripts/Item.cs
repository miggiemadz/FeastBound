using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Item : MonoBehaviour
{
    /* Active: An item that is held by the player and has to be activated manually.
       Passive: An item that provides an immediate constant change. */
    [SerializeField] private string itemType;

    // The name of the item
    [SerializeField] private string itemName;

    // A dictionary of the item and what stat changes it will provide for the player.
    [SerializeField] private Dictionary<string, float> statChanges = new Dictionary<string, float>();

    private bool isEquipped;
    private bool isCollected;

    private void Start()
    {
        
    }
}
