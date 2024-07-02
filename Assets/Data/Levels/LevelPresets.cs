
using UnityEngine;

public static class LevelPresets
{

    private static Level[] levelPresets =
    {
        new Level(new int[,] 
        {
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 },
            { 1, 1, 1, 1 }
        }),
        new Level(new int[,]
        {
            { 0, 0, 1, 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 1, 1, 0, 0 }
        }),
        new Level(new int[,]
        {
            { 1, 1, 1, 1, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 1, 1, 1, 1 }
        }),
        new Level(new int[,]
        {
            { 0, 1, 1, 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 1, 1, 0 },
            { 0, 1, 1, 0, 0, 1, 1, 0 }
        }),
        new Level(new int[,]
        {
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 },
            { 0, 0, 1, 1, 0, 0 }
        }),
        new Level(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 }
        }),
        new Level(new int[,]
        {
            { 0, 1, 1, 0, 0, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 1, 0, 0, 0 }
        })
    };

    public static Level GetRandomLevel()
    {
        int index = UnityEngine.Random.Range(0, levelPresets.GetLength(0));
        return levelPresets[index];
    }

}