using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public WeaponData weaponData;

    public abstract void Fire(Transform shooterTransform);
    public abstract void DecreaseCooldown(float amount);

    public abstract void SetCooldown(float amount);

}
