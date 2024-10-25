using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModifier : MonoBehaviour
{
    // Weapon Stat Modifiers
    private float weaponDamageMod = 1.0f;
    private float weaponFireRateMod = 1.0f;
    private float weaponSizeMod = 1.0f;
    private float weaponReloadSpeedMod = 1.0f;

    // Projectile Stat Modifiers
    private float projectileSizeMod = 1.0f;
    private float projectileDamageMod = 1.0f;
    private float projectileSpeedMod = 1.0f;

    // Player Stats Modifiers
    private float playerSpeedMod = 1.0f;
    private float playerTotalHealthMod = 1.0f;

    // Getters & Setters
    public float WeaponDamageMod { get => weaponDamageMod; set => weaponDamageMod = value; }
    public float WeaponFireRateMod { get => weaponFireRateMod; set => weaponFireRateMod = value; }
    public float WeaponSizeMod { get => weaponSizeMod; set => weaponSizeMod = value; }
    public float WeaponReloadSpeedMod { get => weaponReloadSpeedMod; set => weaponReloadSpeedMod = value; }
    public float ProjectileSizeMod { get => projectileSizeMod; set => projectileSizeMod = value; }
    public float ProjectileDamageMod { get => projectileDamageMod; set => projectileDamageMod = value; }
    public float ProjectileSpeedMod { get => projectileSpeedMod; set => projectileSpeedMod = value; }
    public float PlayerSpeedMod { get => playerSpeedMod; set => playerSpeedMod = value; }
    public float PlayerTotalHealthMod { get => playerTotalHealthMod; set => playerTotalHealthMod = value; }


}
