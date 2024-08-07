using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String", menuName = "ScriptableObjects/Variables/StringVariable")]
public class StringVariable : ScriptableObject
{
    [SerializeField] private string value;

    public string Value { get => value; }
}
