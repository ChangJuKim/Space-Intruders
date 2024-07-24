using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float", menuName = "ScriptableObjects/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    public float value;

    public static implicit operator float(FloatVariable floatVariable)
    {
        return floatVariable.value;
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public void ResetTo(float other)
    {
        value = other;
    }
}
