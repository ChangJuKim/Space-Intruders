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

    public void ResetTo(PlayerStats baseStats)
    {
        health.hp.value = baseStats.health.hp.value;
        acceleration.value = baseStats.acceleration.value;
        maxSpeed.value = baseStats.maxSpeed.value;
        currentPosition = baseStats.currentPosition;
    }
}
