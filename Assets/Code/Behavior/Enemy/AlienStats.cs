using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlienStats", menuName = "ScriptableObjects/AlienStats")]
public class AlienStats : CharacterStats
{
    [SerializeField] private FloatVariable moveCooldown;
    [SerializeField] private FloatVariable moveDistance;

    //public Weapon weapon;
    
    public FloatVariable finishLine;

    public FloatVariable MoveDistance { get => moveDistance; set => moveDistance = value; }
    public FloatVariable MoveCooldown { get => moveCooldown; set => moveCooldown = value; }

    public void ResetTo(AlienStats baseAlienStats)
    {
        MoveCooldown.value = baseAlienStats.MoveCooldown.value;
        MoveDistance.value = baseAlienStats.MoveDistance.value;
        //weapon = baseAlienStats.weapon;
        finishLine.value = baseAlienStats.finishLine.value;
    }
}
