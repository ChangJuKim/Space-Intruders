using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public Vector3 spawnOffset;
    public WeaponData weaponData;

    public void Fire(Transform transform)
    {
        if (weaponData.cooldown <= 0)
        {
            SpawnBullet(transform);
            SetCooldown(weaponData.baseCooldown);
        }
    }
    public void DecreaseCooldown(float amount)
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

    public void SetCooldown(float amount)
    {
        weaponData.cooldown = amount;
    }
}