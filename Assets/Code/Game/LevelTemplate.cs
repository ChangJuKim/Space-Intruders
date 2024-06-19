using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Templates/Level")]
public class LevelTemplate : ScriptableObject
{
    public Alien[,] enemies = new Alien[6,8];
}
