using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EffectIncreaseAtkSpd : ICardEffect
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float amount;

    public void PerformEffect()
    {
        weapon.IncreaseAttackSpeed(amount);
    }
}
