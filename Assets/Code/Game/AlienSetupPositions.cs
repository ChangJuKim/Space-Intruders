using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MultiDimensionalInt
{
    public int[] intArray;
}

[CreateAssetMenu(fileName = "New Level Setup", menuName = "ScriptableObjects/Setup/LevelPositions")]
public class AlienSetupPositions : ScriptableObject
{
    public MultiDimensionalInt[] positions;
}
