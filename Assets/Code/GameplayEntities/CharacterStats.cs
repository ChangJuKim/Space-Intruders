using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject
{

    [SerializeField] private HP health;

    public HP Health { get => health; set => health = value; }

    public void ResetTo(CharacterStats other)
    {
        Health.ResetTo(other.Health);
    }
}
