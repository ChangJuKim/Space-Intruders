using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject
{
    public HP health;

    public void ResetTo(CharacterStats other)
    {
        health.ResetTo(other.health);
    }
}
