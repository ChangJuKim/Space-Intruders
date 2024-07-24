using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlienStats", menuName = "ScriptableObjects/AlienStats")]
public class AlienStats : CharacterStats
{
    public FloatVariable moveCooldown;
    public FloatVariable moveDistance;

    //public Weapon weapon;
    
    public FloatVariable finishLine;

    public void ResetTo(AlienStats baseAlienStats)
    {
        moveCooldown.value = baseAlienStats.moveCooldown.value;
        moveDistance.value = baseAlienStats.moveDistance.value;
        //weapon = baseAlienStats.weapon;
        finishLine.value = baseAlienStats.finishLine.value;
    }
}
