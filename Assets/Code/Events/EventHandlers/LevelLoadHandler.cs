using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadHandler : MonoBehaviour
{
    public void loadLevel(LoadLevelParameters param)
    {
        Debug.Log("Loaded level " + param.level + " with difficulty " + param.difficulty);
    }
}
