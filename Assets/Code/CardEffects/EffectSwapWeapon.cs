using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwapWeapon : ICardEffect
{
    public WeaponShooter shooter;
    public Weapon weapon1;
    public Weapon weapon2;
    

    public void PerformEffect()
    {
        if (shooter.weapon != weapon1)
        {
            shooter.SwapWeapon(weapon1);
        } else
        {
            shooter.SwapWeapon(weapon2);
        }
    }
}
