
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public static class LevelPresets
{
    private static HashSet<int> set = new HashSet<int>();
    private static Queue<int> queue = new Queue<int>();
    private static readonly int numLevelsBeforeRepeat = 3; 

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
        // Prevent accidentally creating an infinite loop by making numLevels too large
        if (queue.Count < levelPresets.Length)
        {
            while (set.Contains(index))
            {
                index = Random.Range(0, levelPresets.GetLength(0));
            }
        }

        if (queue.Count >= numLevelsBeforeRepeat)
        {
            int other = queue.Dequeue();
            set.Remove(other);
        }

        queue.Enqueue(index);
        set.Add(index);

        return levelPresets[index];
    }

}