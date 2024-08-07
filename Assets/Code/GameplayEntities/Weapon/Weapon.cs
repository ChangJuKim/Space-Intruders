using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public Vector3 spawnOffset;

    [SerializeField] private AttackSpeed attackSpeed;
    private float cooldown;
    private float baseCooldown;

    [SerializeField] private float damage;
    [SerializeField] private GameObject bulletModel;

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
            cooldown = 0;
            attackSpeed.ResetTo(other.attackSpeed);
            baseCooldown = attackSpeed.GetCooldown();

            spawnOffset = other.spawnOffset;
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

    // TODO: Need to fix this architecture
    // increase attackspeed is just calling attack speed and this class needs to understand the attack speed underlying structure to understand why it's calling GetCooldown()
    public void IncreaseAttackSpeed(float percent)
    {
        attackSpeed.AddBonusAttackSpeed(percent);
        baseCooldown = attackSpeed.GetCooldown();
    }

    // TODO: Need to fix this architecture too
    public void DecreaseAttackSpeed(float percent)
    {
        attackSpeed.DecreaseBonusAttackSpeed(percent);
        baseCooldown = attackSpeed.GetCooldown();
    }
}