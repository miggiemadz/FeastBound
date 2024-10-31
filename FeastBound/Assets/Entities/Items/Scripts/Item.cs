using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Identifiers")]
    /* StatMod: An item that is held by the player and has to be activated manually.
       Resource: An item that provides an immediate constant change. */
    [SerializeField] private string itemType;

    // The name of the item
    [SerializeField] private string itemName;

    // The Rarity of the item.
    [SerializeField] private string itemRarity;

    // A dictionary of the item and what stat changes it will provide for the player.
    private Dictionary<string, float> statChanges = new Dictionary<string, float>();

    private StatModifier statModifier;

    private bool isEquipped;
    private bool isCollected;

    public string ItemType { get => this.itemType; set => this.itemType = value; }
    public string ItemName { get => this.itemName; set => this.itemName = value; }
    public Dictionary<string, float> StatChanges { get => this.statChanges; set => this.statChanges = value; }
    public bool IsEquipped { get => this.isEquipped; set => this.isEquipped = value; }
    public bool IsCollected { get => this.isCollected; set => this.isCollected = value; }

    private void Awake()
    {
        statModifier = GameObject.Find("StatModifier").GetComponent<StatModifier>();
        try
        {
            string[] itemFileLines = File.ReadAllLines("Assets/Entities/Universal/Scripts/roguelike_items.txt");

            foreach (string line in itemFileLines) 
            { 
                if (line == ItemName)
                {
                    int statLineNum = Array.IndexOf(itemFileLines, line) + 1;
                    string[] statLine = itemFileLines[statLineNum].Split(" ");

                    for (int i = 0; i < statLine.Length; i += 2) 
                    { 
                        string statName = statLine[i];
                        string statMod = statLine[i + 1];

                        float.TryParse(statMod, out float value);

                        StatChanges[statName] = value;
                    }
                    break;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateStatModifier()
    {
        foreach (String stat in StatChanges.Keys)
        {
            switch (stat)
            {
                case "movementSpeed":
                    statModifier.PlayerSpeedMod *= StatChanges[stat]; break;
                case "fireRate":
                    statModifier.WeaponFireRateMod *= StatChanges[stat]; break;
                case "damage":
                    statModifier.WeaponDamageMod *= StatChanges[stat];
                    statModifier.ProjectileDamageMod *= StatChanges[stat]; break;
                case "reloadSpeed":
                    statModifier.WeaponReloadSpeedMod /= StatChanges[stat]; break;
                case "bulletSpeed":
                    statModifier.ProjectileSpeedMod *= StatChanges[stat]; break;
                case "size":
                    statModifier.ProjectileSizeMod *= StatChanges[stat];
                    statModifier.WeaponSizeMod *= StatChanges[stat]; break;
                case "maxHealth":
                    statModifier.PlayerTotalHealthMod *= StatChanges[stat]; break;
            }
        }
    }

    public void UpdateResources()
    {

    }

    private void Update()
    {

    }
}
