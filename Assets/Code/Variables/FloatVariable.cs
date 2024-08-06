using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float", menuName = "ScriptableObjects/Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float value;

    public float Value { get => value; set => this.value = value; }

    public static implicit operator float(FloatVariable floatVariable)
    {
        return floatVariable.Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public void ResetTo(float other)
    {
        Value = other;
    }
}
