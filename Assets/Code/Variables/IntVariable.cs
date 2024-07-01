using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Integer", menuName = "ScriptableObjects/Variables/IntVariable")]
public class IntVariable : ScriptableObject
{
    public int value;

    public static implicit operator int(IntVariable floatVariable)
    {
        return floatVariable.value;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
