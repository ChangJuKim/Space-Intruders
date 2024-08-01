using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Speed", menuName = "ScriptableObjects/Stats/AttackSpeed")]
public class AttackSpeed : ScriptableObject
{
    public FloatVariable baseAttackSpeed;
    public FloatVariable attackSpeedRatio;

    private float bonusAttackSpeed; // Additive bonuses
    private float modifier; // Multiplicative. Mostly only used with debuffs

    private float weaponCooldown;

    public void OnEnable()
    {
        bonusAttackSpeed = 0;
        modifier = 1;
    }

    public float GetCooldown()
    {
        CalculateCooldown();
        return weaponCooldown;
    }

    private void CalculateCooldown()
    {
        float attackSpeed = (baseAttackSpeed + (attackSpeedRatio * bonusAttackSpeed / 100)) * modifier;
        // Hard cap of one attack every 20 seconds
        // You know, just to cover my back if I create some crazy cards
        attackSpeed = Mathf.Max(attackSpeed, 0.05f);
        weaponCooldown = 1 / attackSpeed;
    }

    // Adding attack speed is additive
    public void AddBonusAttackSpeed(float percentage)
    {
        bonusAttackSpeed += percentage;
    }

    // Decreasing attack speed is multiplicative
    public void DecreaseBonusAttackSpeed(float percentage)
    {
        // Can't decrease by less than 0.01
        percentage = Mathf.Max(-99.99f, Mathf.Abs(percentage) * -1);
        CalculateModifier(percentage);
    }

    // Don't think I'll ever use this but who knows
    public void AddBonusAttackSpeedMultiplicative(float percentage)
    {
        percentage = Mathf.Abs(percentage);
        CalculateModifier(percentage);
    }

    // Negative percentage means decrease, positive means increase
    private void CalculateModifier(float percentage)
    {
        float newMultiplier = modifier * (1 + percentage);

        if (newMultiplier > 0.6)
        {
            modifier = newMultiplier;
        }
        else if (newMultiplier > 0.2)
        {
            modifier = newMultiplier * 0.6f + 0.24f;
        }
        else
        {
            modifier = newMultiplier * 0.2f + 0.32f;
        }
    }

    public void ResetTo(AttackSpeed other)
    {
        baseAttackSpeed.value = other.baseAttackSpeed.value;
        attackSpeedRatio.value = other.attackSpeedRatio.value;
        bonusAttackSpeed = other.bonusAttackSpeed;
        modifier = other.modifier;
        CalculateCooldown();
    }
}
