using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private readonly int[,] level;

    public Level(int[,] level)
    {
        this.level = level;
    }

    public int[,] getLevel()
    {
        return level;
    }

    public override string ToString()
    {
        string s = "[";
        for (int i = 0; i < level.GetLength(0); i++)
        {

            s += i == 0 ? "[" : " [";
            for (int j = 0; j < level.GetLength(1); j++)
            {
                s += j == 0 ? level[i, j] : ", " + level[i, j];
            }
            s += "]\n";
        
        }
        s += "]";
        return s;
    }
}
