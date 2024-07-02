using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{

    public IntVariable level;
    public Alien alien;

    public AlienSetupDimensions dimensions;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }


    public void GenerateLevel()
    {
        Level level = LoadLevel();
        Alien[,] alienPositions = GenerateAliens(level);
        StartCoroutine(SpawnAliens(alienPositions));
    }

    public Level LoadLevel()
    {
        Level level = LevelPresets.GetRandomLevel();
        return level;
    }

    public Level LoadLevelManual()
    {
        int numRow = 4;
        int numCols = 6;
        int percentChance = 50;

        int[,] positions = new int[4,6];

        for (int i = 0; i < numRow; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (Random.Range(0, 100) < percentChance)
                {
                    positions[i,j] = 1;
                } 
                else
                {
                    positions[i,j] = 0;
                }
            }
        }

        return new Level(positions);
    }

    private Alien[,] GenerateAliens(Level level)
    {
        int[,] positions = level.getLevel();
        Alien[,] aliens = new Alien[positions.GetLength(0),positions.GetLength(1)];

        for (int i = 0; i < positions.GetLength(0); i++)
        {
            for (int j = 0; j < positions.GetLength(1); j++)
            {
                if (positions[i, j] == 0)
                {
                    aliens[i, j] = null;
                }
                else
                {
                    aliens[i, j] = alien;
                }
            }
        }

        string s = "[";
        for (int i = 0; i < aliens.GetLength(0); i++)
        {

            s += i == 0 ? "[" : " [";
            for (int j = 0; j < aliens.GetLength(1); j++)
            {
                s += j == 0 ? aliens[i, j] : ", " + aliens[i, j];
            }
            s += "]\n";

        }
        s += "]";

        return aliens;
    }

    private IEnumerator SpawnAliens(Alien[,] aliens)
    {
        if (aliens.GetLength(0) <= 1 || aliens.GetLength(1) <= 1)
        {
            yield break;
        }

        while (!SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("GameScene")))
        {
            yield return null;
        }

        float xDelta = (float)Mathf.Abs(dimensions.rightX - dimensions.leftX) / (aliens.GetLength(1) - 1);
        float yDelta = (float)Mathf.Abs(dimensions.bottomY - dimensions.topY) / (aliens.GetLength(0) - 1);

        
        for (int i = 0; i < aliens.GetLength(0); i++)
        {
            float y = dimensions.topY - i * yDelta;
            for (int j = 0; j < aliens.GetLength(1); j++)
            {
                float x = dimensions.leftX + j * xDelta;

                if (aliens[i, j] != null)
                {
                    Instantiate(aliens[i, j], new Vector3(x, y, 0), transform.rotation, this.transform);
                }
            }
        }
    }
}
