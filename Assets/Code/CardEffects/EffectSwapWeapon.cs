using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAddBounce : ICardEffect
{
    public Weapon weapon;
    // Total variation in degrees
    public float firingAngle;

    public void PerformEffect()
    {
        BulletScript bulletScript = weapon.getBulletScript();
        if (bulletScript != null)
        {
            bool hasBounce = bulletScript.toggleBounce();
            bulletScript.bulletData.firingAngle = hasBounce ? firingAngle : 0;
        }
    }
}
