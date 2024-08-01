using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : CharacterStats
{
    public FloatVariable acceleration;
    public FloatVariable maxSpeed;
    public Vector3 currentPosition;
    public Weapon weapon;

    public void ResetTo(PlayerStats other)
    {
        Debug.Log("Reset player stats");
        health.hp.value = other.health.hp.value;
        acceleration.value = other.acceleration.value;
        maxSpeed.value = other.maxSpeed.value;
        currentPosition = other.currentPosition;
        weapon.ResetTo(other.weapon);
    }
}
