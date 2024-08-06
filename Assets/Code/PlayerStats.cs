using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : CharacterStats
{
    public FloatVariable moveSpeed;
    public Weapon weapon;

    public void ResetTo(PlayerStats other)
    {
        Debug.Log("Reset player stats");
        Health.ResetTo(other.Health);
        moveSpeed.value = other.moveSpeed.value;
        weapon.ResetTo(other.weapon);
    }
}
