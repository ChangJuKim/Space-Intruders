using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EffectIncreaseAtkSpd : ICardEffect
{
    public Weapon weapon;
    public float amount;

    public void PerformEffect()
    {
        weapon.IncreaseAttackSpeed(amount);
    }
}
