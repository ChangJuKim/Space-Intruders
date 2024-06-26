using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadLevelParams", menuName = "ScriptableObjects/Variables/LoadLevelParam")]
public class LoadLevelParameters : EventParametersBase
{
    public int difficulty;
    public int level;
}
