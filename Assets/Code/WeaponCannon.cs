using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cannon", menuName = "ScriptableObjects/Weapons/Cannon")]
public class WeaponCannon : Weapon
{
    public Vector3 spawnOffset;

    public override void Fire(Transform transform)
    {
        if (weaponData.cooldown <= 0)
        {
            weaponData.cooldown = weaponData.baseCooldown;
            SpawnBullet(transform);
        }
    }

    public override void DecreaseCooldown(float amount)
    {
        if (weaponData.cooldown > 0)
        {
            weaponData.cooldown -= amount;
        }
    }

    private void SpawnBullet(Transform transform)
    {
        Instantiate(weaponData.bulletModel, transform.position + spawnOffset, transform.rotation);
    }
}
