using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CreateLevel : MonoBehaviour
{

    public IntVariable level;
    public Alien alien;

    public AlienSetupDimensions dimensions;


    // Start is called before the first frame update
    void Start()
    {
        LoadAliens();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAliens()
    {
        int numRow = 4;
        int numCols = 6;
        int percentChance = 50;

        int[][] positions = new int[numRow][];

        for (int i = 0; i < numRow; i++)
        {
            positions[i] = new int[numCols];
            for (int j = 0; j < numCols; j++)
            {
                if (UnityEngine.Random.Range(0, 100) < percentChance)
                {
                    positions[i][j] = 1;
                } 
                else
                {
                    positions[i][j] = 0;
                }
            }
        }


        Alien[][] alienPositions = GenerateAliens(positions);
        StartCoroutine(SpawnAliens(alienPositions));
    }

    private Alien[][] GenerateAliens(int[][] positions)
    {
        Alien[][] aliens = new Alien[positions.Length][];

        for (int i = 0; i < positions.Length; i++)
        {
            aliens[i] = new Alien[positions[i].Length];
            for (int j = 0; j < positions[i].Length; j++)
            {
                Debug.Log(positions[i][j]);
                if (positions[i][j] == 0)
                {
                    aliens[i][j] = null;
                }
                else
                {
                    aliens[i][j] = alien;
                }
            }
        }

        return aliens;
    }

    private IEnumerator SpawnAliens(Alien[][] aliens)
    {
        if (aliens.Length <= 1 || aliens[0].Length <= 1)
        {
            yield break;
        }

        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("GameScene")))
        {
            Debug.Log("Active Scene: " + SceneManager.GetActiveScene().name);
            yield return null;
        }

        float xDelta = (float)Mathf.Abs(dimensions.rightX - dimensions.leftX) / (aliens[0].Length - 1);
        float yDelta = (float)Mathf.Abs(dimensions.bottomY - dimensions.topY) / (aliens.Length - 1);

        for (int i = 0; i < aliens.Length; i++)
        {
            float y = dimensions.bottomY + i * yDelta;
            for (int j = 0; j < aliens[i].Length; j++)
            {
                float x = dimensions.leftX + j * xDelta;

                if (aliens[i][j] != null)
                {
                    Instantiate(aliens[i][j], new Vector3(x, y, 0), transform.rotation, this.transform);
                }
            }
        }
    }
}
