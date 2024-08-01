using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public Vector3 spawnOffset;
    public float cooldown;
    public float baseCooldown;
    public float damage;
    public GameObject bulletModel;

    public void Fire(Transform transform)
    {
        if (cooldown <= 0)
        {
            SpawnBullet(transform);
            SetCooldown(baseCooldown);
        }
    }
    public void DecreaseCooldown(float amount)
    {
        if (cooldown > 0)
        {
            cooldown -= amount;
        }
    }

    private void SpawnBullet(Transform transform)
    {
        Instantiate(bulletModel, transform.position + spawnOffset, transform.rotation);
    }

    public void SetCooldown(float amount)
    {
        cooldown = amount;
    }

    public void ResetTo(Weapon other)
    {
        if (other != null)
        {
            spawnOffset = other.spawnOffset;
            cooldown = other.cooldown;
            baseCooldown = other.baseCooldown;
            damage = other.damage;

            getBulletScript().ResetTo();
        } 
        else
        {
            throw new ArgumentException("Weapon reset failed: Other weapon is null");
        }
    }

    public BulletScript getBulletScript()
    {
        BulletScript bulletScript = bulletModel.GetComponent<BulletScript>();
        if (bulletScript != null)
        {
            return bulletScript;
        }
        else
        {
            throw new NullReferenceException("Weapon unable to get BulletScript");
        }
    }
}