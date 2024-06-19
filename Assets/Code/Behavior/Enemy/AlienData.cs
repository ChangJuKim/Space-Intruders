using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AlienData", menuName = "ScriptableObjects/AlienData")]
public class AlienData : ScriptableObject
{
    public FloatVariable moveCooldown;
    public FloatVariable moveDistance;

    public Weapon weapon;
    
    public FloatVariable finishLine;
}
