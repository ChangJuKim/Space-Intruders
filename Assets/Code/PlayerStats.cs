using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : CharacterStats
{
    public FloatVariable moveSpeed;
    public Vector3 currentPosition;
    public Weapon weapon;

    public void ResetTo(PlayerStats other)
    {
        Debug.Log("Reset player stats");
        health.hp.value = other.health.hp.value;
        moveSpeed.value = other.moveSpeed.value;
        currentPosition = other.currentPosition;
        weapon.ResetTo(other.weapon);
    }
}
